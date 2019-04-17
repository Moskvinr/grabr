import { PipeTransform, Pipe } from '@angular/core';

@Pipe({ name: 'errorMessages' })
export class FormsErrorMessagesPipe implements PipeTransform {
    transform(errors: object, messages?): string[] {
        if (errors) {
            const errorsKeys = Object.keys(errors);
            return errorsKeys.reduce((result, errorKey) => {
                result.push(messages && messages[errorKey]);
                return result;
            }, []);
        }
        return [];
    }
}
