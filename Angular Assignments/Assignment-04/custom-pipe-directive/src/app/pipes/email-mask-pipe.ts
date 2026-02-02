import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'emailMask'
})
export class EmailMaskPipe implements PipeTransform {

   transform(email: string): string {
    if (!email || !email.includes('@')) {
      return email;
    }

    const [name, domain] = email.split('@');
    const maskedName = name[0] + '*'.repeat(name.length - 1);

    return `${maskedName}@${domain}`;
  }

}
