import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'app-animation-roll',
  templateUrl: './animation-roll.component.html',
  styleUrls: ['./animation-roll.component.scss'],
  animations: [
    trigger('content', [
      state('hidden', style({
        height: '0',
        overflow: 'hidden'
      })),
      state('visible', style({
        height: '*',
        overflow: 'visible'
      })),
      transition('visible <=> hidden', animate('550ms cubic-bezier(0.63, 0, 0.32, 1)'))
    ])
  ]
})
export class AnimationRollComponent implements OnChanges {
  @Input() opened = false;
  @Output() hide = new EventEmitter<void>();
  @Output() show = new EventEmitter<void>();

  public isOpened: boolean;
  private animating = false;

  ngOnChanges(changes: SimpleChanges) {
    if (changes['opened']) {
      this.isOpened = changes['opened'].currentValue;
      this.animating = true;
    }
  }

  public onToggleDone(event: any): void {
    if (event.fromState === 'visible' && event.toState === 'hidden') {
      this.hide.emit();
    }
    if (event.fromState === 'hidden' && event.toState === 'visible') {
      this.show.emit();
    }
    this.animating = false;
  }
}
