using System.Text;
using System.Text.Json;
using BackOffice.Blazor.Models;

namespace BackOffice.Blazor.Services
{
    public class ClinicalGraphQLService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ClinicalGraphQLService> _logger;
        private readonly string _graphqlUrl;

        public ClinicalGraphQLService(HttpClient httpClient, IConfiguration configuration, ILogger<ClinicalGraphQLService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _graphqlUrl = configuration.GetConnectionString("GraphQLServer") ?? "http://localhost:5001/graphql";
        }

        public async Task<ClinicalInputResponse> SavePatientDataAsync(ClinicalInputData patientData)
        {
            try
            {
                var query = @"
                    mutation SavePatientData($input: ClinicalInputDataInput!) {
                        savePatientData(input: $input) {
                            success
                            message
                            patientId
                        }
                    }";

                var request = new GraphQLRequest
                {
                    Query = query,
                    Variables = new { input = patientData }
                };

                var response = await SendGraphQLRequestAsync<ClinicalInputResponseWrapper>(request);
                return response?.SavePatientData ?? new ClinicalInputResponse 
                { 
                    Success = false, 
                    Message = "No response from server" 
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving patient data");
                return new ClinicalInputResponse 
                { 
                    Success = false, 
                    Message = "Error saving patient data: " + ex.Message 
                };
            }
        }

        public async Task<ClinicalInputData?> GetPatientDataAsync(string patientId)
        {
            try
            {
                var query = @"
                    query GetPatientData($patientId: String!) {
                        patient(id: $patientId) {
                            patientId
                            patientName
                            dateOfBirth
                            gender
                            phoneNumber
                            address
                            city
                            state
                            zipCode
                            emergencyContact
                            emergencyPhone
                            primaryPhysician
                            diagnosis
                            medications
                            allergies
                            notes
                            admissionDate
                            insuranceProvider
                            insurancePolicyNumber
                            priority
                            isActive
                        }
                    }";

                var request = new GraphQLRequest
                {
                    Query = query,
                    Variables = new { patientId }
                };

                var response = await SendGraphQLRequestAsync<ClinicalDataWrapper>(request);
                return response?.Patient;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "GraphQL service unavailable, using sample data for patient ID: {PatientId}", patientId);
                
                // Fallback to sample data when GraphQL is not available
                var sampleData = SampleDataService.GetSamplePatients();
                return sampleData.FirstOrDefault(p => p.PatientId.Equals(patientId, StringComparison.OrdinalIgnoreCase));
            }
        }

        public async Task<List<ClinicalInputData>> SearchPatientsAsync(string searchTerm)
        {
            try
            {
                var query = @"
                    query SearchPatients($searchTerm: String!) {
                        searchPatients(searchTerm: $searchTerm) {
                            patientId
                            patientName
                            dateOfBirth
                            gender
                            phoneNumber
                            address
                            city
                            state
                            zipCode
                            emergencyContact
                            emergencyPhone
                            primaryPhysician
                            diagnosis
                            medications
                            allergies
                            notes
                            admissionDate
                            insuranceProvider
                            insurancePolicyNumber
                            priority
                            isActive
                        }
                    }";

                var request = new GraphQLRequest
                {
                    Query = query,
                    Variables = new { searchTerm }
                };

                var response = await SendGraphQLRequestAsync<ClinicalSearchWrapper>(request);
                return response?.SearchPatients ?? new List<ClinicalInputData>();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "GraphQL service unavailable, using sample data for search term: {SearchTerm}", searchTerm);
                
                // Fallback to sample data when GraphQL is not available
                var sampleData = SampleDataService.GetSamplePatients();
                return sampleData.Where(p => 
                    p.PatientName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    p.PatientId.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    p.Diagnosis.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }
        }

        private async Task<T> SendGraphQLRequestAsync<T>(GraphQLRequest request) where T : class
        {
            try
            {
                var json = JsonSerializer.Serialize(request, new JsonSerializerOptions 
                { 
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
                });
                
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync(_graphqlUrl, content);
                
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<GraphQLResponse<T>>(responseJson, new JsonSerializerOptions 
                    { 
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
                    });
                    
                    if (result?.Errors != null && result.Errors.Any())
                    {
                        var errorMessage = string.Join(", ", result.Errors.Select(e => e.Message));
                        _logger.LogError("GraphQL errors: {Errors}", errorMessage);
                        return default(T)!;
                    }
                    
                    return result?.Data ?? default(T)!;
                }
                else
                {
                    _logger.LogError("HTTP error: {StatusCode} - {ReasonPhrase}", response.StatusCode, response.ReasonPhrase);
                    return default(T)!;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending GraphQL request");
                return default(T)!;
            }
        }
    }

    // Internal classes for GraphQL communication
    public class GraphQLRequest
    {
        public string Query { get; set; } = string.Empty;
        public object? Variables { get; set; }
    }

    public class GraphQLResponse<T>
    {
        public T? Data { get; set; }
        public List<GraphQLError>? Errors { get; set; }
    }

    public class GraphQLError
    {
        public string Message { get; set; } = string.Empty;
    }

    // Wrapper classes for GraphQL responses
    public class ClinicalInputResponseWrapper
    {
        public ClinicalInputResponse SavePatientData { get; set; } = new();
    }

    public class ClinicalDataWrapper
    {
        public ClinicalInputData? Patient { get; set; }
    }

    public class ClinicalSearchWrapper
    {
        public List<ClinicalInputData>? SearchPatients { get; set; }
    }
}
