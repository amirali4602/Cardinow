import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'relativeTime'
})
export class RelativeTimePipe implements PipeTransform {

  transform(value: string): string {

    const now = new Date();
    const loginDate = new Date(value);
    const diffMs = now.getTime() - loginDate.getTime();
    const diffHours = Math.floor(diffMs / (1000 * 60 * 60));

    if (diffHours < 1) {
      return 'Just now';
    }

    if (diffHours < 24) {
      return `${diffHours} hours ago`;
    }

    return 'Yesterday';
  }
}
