import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { FormlyFormOptions, FormlyFieldConfig } from '@ngx-formly/core';

@Component({
  selector: 'app-order-form',
  templateUrl: './order-form.component.html',
  styleUrls: ['./order-form.component.scss']
})
export class OrderFormComponent implements OnInit {

  @Input() order: any;
  @Output() cancel = new EventEmitter<{ originalEvent: Event }>();
  @Output() success = new EventEmitter<Order>();

  orderForm = new FormGroup({});
  model: any = {};
  options: FormlyFormOptions = {};
  fields: FormlyFieldConfig[];

  constructor() { }

  ngOnInit() {
    Object.assign(this.model, this.order);
    this.fillForm();
  }

  fillForm() {
    this.fields = [
      {
        key: 'name',
        type: 'input',
        defaultValue: this.order.name,
        templateOptions: {
          label: 'Название',
          placeholder: 'Введите название',
          required: true,
          type: 'text'
        }
      },
      {
        key: 'description',
        type: 'textarea',
        defaultValue: this.order.description,
        templateOptions: {
          label: 'Описание',
          placeholder: 'Введите описание',
          required: true,
          rows: 5
        }
      },
      {
        key: 'productPrice',
        type: 'input',
        defaultValue: this.order.productPrice,
        templateOptions: {
          label: 'Цена',
          placeholder: 'Введите цену продукта',
          required: true,
          type: 'number'
        }
      },
      {
        key: 'count',
        type: 'input',
        defaultValue: this.order.count,
        templateOptions: {
          label: 'Количество',
          placeholder: 'Введите количество, которое нужно купить',
          required: true,
          type: 'number'
        }
      },
      {
        key: 'reward',
        type: 'input',
        defaultValue: this.order.reward,
        templateOptions: {
          label: 'Вознаграждение',
          placeholder: 'Введите вознаграждение доставщику',
          required: true,
          type: 'number'
        }
      },
      {
        key: 'productLink',
        type: 'input',
        defaultValue: this.order.productLink,
        templateOptions: {
          label: 'Ссылка на магазин/продукт',
          placeholder: 'Введите ссылку на магазин/продукт',
          required: true,
          type: 'text'
        }
      },
      {
        key: 'productImage',
        type: 'input',
        defaultValue: this.order.productImage,
        templateOptions: {
          label: 'Ссылка на изображение товара',
          placeholder: 'Введите ссылку на изображение товара',
          required: false,
          type: 'text'
        }
      },
    ];
  }

  submit($event) {
    $event.preventDefault();
    if (this.orderForm.valid) {
      const order = Object.assign({}, this.order, this.orderForm.value, {});
      this.success.emit(order);
    }
  }

  cancelClicked($event) {
    $event.preventDefault();
    this.cancel.emit({ originalEvent: $event });
  }

}
