import { AbstractControl } from '@angular/forms';

export function confirmPasswordValidator(group: AbstractControl) {
    const passwordInput = group.get('password');
    const passwordConfirmationInput = group.get('confirmPassword');
    if (passwordInput.value !== passwordConfirmationInput.value) {
        passwordConfirmationInput.setErrors({ passwordDifferent: true });
    } else {
        passwordConfirmationInput.enable({ onlySelf: true });
    }
    return null;
}
