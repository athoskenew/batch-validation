import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Material } from '../../models/Materials';

@Component({
  selector: 'app-material-form',
  templateUrl: './material-form.component.html',
  styleUrl: './material-form.component.css'
})
export class MaterialFormComponent implements OnInit {

  @Output() onSubmit = new EventEmitter<Material>();

  materialsForm!: FormGroup;

  constructor(){}

  ngOnInit(): void {
    this.materialsForm = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      creationDate: new FormControl(new Date()),
      materialQualityCharacteristics: new FormControl(null),
      materialQualityVision: new FormControl(null)
    })
  }

  submit(){
    this.onSubmit.emit(this.materialsForm.value);
    
  }

}
