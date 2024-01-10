import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { QualityCharacteristicService } from '../../services/QualityCharacteristic/quality-characteristic.service';
import { ActivatedRoute, Router } from '@angular/router';
import { QualityCharacteristic } from '../../models/QualityCharacteristic';

@Component({
  selector: 'app-new-characteristic',
  templateUrl: './new-characteristic.component.html',
  styleUrl: './new-characteristic.component.css'
})
export class NewCharacteristicComponent implements OnInit{

  materialId!: number;
  qualityCharacteristicForm!: FormGroup;

  constructor(
    private qualityCharacteristicService: QualityCharacteristicService,
    private route: ActivatedRoute, 
    private router: Router
  ){}


  ngOnInit(): void {
    this.materialId = Number(this.route.snapshot.paramMap.get('id'));
    
    this.qualityCharacteristicForm = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      type: new FormControl(0, [Validators.required]),
      justify: new FormControl(true),
      decimalPlaces: new FormControl(0),
      inferiorLimit: new FormControl(0, [Validators.required]),
      superiorLimit: new FormControl(0, [Validators.required]),
      materialModelId: new FormControl(this.materialId)
    })
  }


  submit(){
    const characteristic : QualityCharacteristic = this.qualityCharacteristicForm.value;
    this.qualityCharacteristicService.CreateCharacteristic(characteristic, this.materialId).subscribe(()=>{
      this.router.navigate([`/characteristics/${this.materialId}`]);
    })
  
  }

  backToCharacteristics(){
    this.router.navigate([`/characteristics/${this.materialId}`]);
  }
}
