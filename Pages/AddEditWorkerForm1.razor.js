// AddEditWorkerForm1.razor.js - JavaScript interop for the converted HTML form

window.initializeFormInterop = () => {
    initializePhoneFormatting();
    initializeNotifications();
};

window.showNotification = (message, type = 'info') => {
    const notification = document.createElement('div');
    
    let backgroundColor, borderColor;
    switch (type) {
        case 'success':
            backgroundColor = '#28a745';
            borderColor = '#1e7e34';
            break;
        case 'error':
            backgroundColor = '#dc3545';
            borderColor = '#c82333';
            break;
        case 'warning':
            backgroundColor = '#ffc107';
            borderColor = '#e0a800';
            break;
        default:
            backgroundColor = '#17a2b8';
            borderColor = '#138496';
    }
    
    notification.style.cssText = `
        position: fixed;
        top: 20px;
        right: 20px;
        background: ${backgroundColor};
        color: white;
        padding: 15px 20px;
        border-radius: 8px;
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.3);
        z-index: 10000;
        animation: slideInRight 0.3s ease;
        max-width: 400px;
        border-left: 4px solid ${borderColor};
        font-weight: 500;
    `;
    
    notification.textContent = message;
    document.body.appendChild(notification);

    // Auto-remove after 3 seconds
    setTimeout(() => {
        notification.style.animation = 'slideOutRight 0.3s ease';
        setTimeout(() => {
            if (notification.parentNode) {
                notification.remove();
            }
        }, 300);
    }, 3000);
};

function initializePhoneFormatting() {
    // Apply phone formatting to all phone input fields
    document.querySelectorAll('input[type="tel"], input[maxlength="15"][class*="phone"]').forEach(function(input) {
        input.addEventListener('input', function(e) {
            let value = e.target.value.replace(/\D/g, '');
            if (value.length >= 6) {
                value = value.substring(0, 3) + '-' + value.substring(3, 6) + '-' + value.substring(6, 10);
            } else if (value.length >= 3) {
                value = value.substring(0, 3) + '-' + value.substring(3);
            }
            e.target.value = value;
        });
    });
}

function initializeNotifications() {
    // Add CSS animations for notifications if they don't exist
    if (!document.querySelector('#notification-styles')) {
        const style = document.createElement('style');
        style.id = 'notification-styles';
        style.textContent = `
            @keyframes slideInRight {
                from { transform: translateX(100%); opacity: 0; }
                to { transform: translateX(0); opacity: 1; }
            }
            
            @keyframes slideOutRight {
                from { transform: translateX(0); opacity: 1; }
                to { transform: translateX(100%); opacity: 0; }
            }
            
            /* Enhanced form validation styles */
            .validation-message {
                color: #dc3545;
                font-size: 0.875rem;
                margin-top: 0.25rem;
                display: block;
            }
            
            .field-validation-error {
                color: #dc3545;
                font-size: 0.875rem;
                margin-top: 0.25rem;
            }
            
            .input-validation-error {
                border-color: #dc3545 !important;
                box-shadow: 0 0 0 0.2rem rgba(220, 53, 69, 0.25) !important;
            }
            
            /* Loading overlay */
            .loading-overlay {
                position: fixed;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                background: rgba(0, 0, 0, 0.5);
                display: flex;
                justify-content: center;
                align-items: center;
                z-index: 9999;
            }
            
            .loading-spinner {
                width: 40px;
                height: 40px;
                border: 4px solid #f3f3f3;
                border-top: 4px solid #0066cc;
                border-radius: 50%;
                animation: spin 1s linear infinite;
            }
            
            /* Enhanced button interactions */
            .c-button:active {
                transform: translateY(1px);
            }
            
            .c-button:disabled {
                opacity: 0.6;
                cursor: not-allowed;
                transform: none !important;
            }
            
            /* Tab transition effects */
            .k-content {
                transition: opacity 0.3s ease;
            }
            
            .k-content:not(.k-active) {
                opacity: 0;
            }
            
            .k-content.k-active {
                opacity: 1;
            }
        `;
        document.head.appendChild(style);
    }
}

window.showLoadingOverlay = (show = true) => {
    const existingOverlay = document.querySelector('.loading-overlay');
    
    if (show && !existingOverlay) {
        const overlay = document.createElement('div');
        overlay.className = 'loading-overlay';
        overlay.innerHTML = '<div class="loading-spinner"></div>';
        document.body.appendChild(overlay);
    } else if (!show && existingOverlay) {
        existingOverlay.remove();
    }
};

window.validateForm = () => {
    const form = document.querySelector('form');
    const requiredFields = form.querySelectorAll('[required]');
    let isValid = true;
    
    requiredFields.forEach(field => {
        const value = field.value.trim();
        const wrapper = field.closest('.k-form-field-wrap');
        
        // Remove previous validation states
        field.classList.remove('input-validation-error');
        const existingError = wrapper.querySelector('.field-validation-error');
        if (existingError) {
            existingError.remove();
        }
        
        if (!value) {
            isValid = false;
            field.classList.add('input-validation-error');
            
            const errorMsg = document.createElement('div');
            errorMsg.className = 'field-validation-error';
            errorMsg.textContent = 'This field is required.';
            wrapper.appendChild(errorMsg);
        }
    });
    
    return isValid;
};

window.formatPhoneNumber = (input) => {
    let value = input.value.replace(/\D/g, '');
    if (value.length >= 6) {
        value = value.substring(0, 3) + '-' + value.substring(3, 6) + '-' + value.substring(6, 10);
    } else if (value.length >= 3) {
        value = value.substring(0, 3) + '-' + value.substring(3);
    }
    input.value = value;
};

window.generateWorkerId = () => {
    // Generate a sample worker ID - in real implementation this would come from the server
    const timestamp = Date.now().toString().slice(-6);
    const random = Math.floor(Math.random() * 100).toString().padStart(2, '0');
    return `WRK${timestamp}${random}`;
};

// Initialize when the module loads
document.addEventListener('DOMContentLoaded', function() {
    if (typeof window.initializeFormInterop === 'function') {
        window.initializeFormInterop();
    }
});
