import { Component, OnInit } from '@angular/core';
import { BatchService } from '../../services/Batch/batch.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Batch } from '../../models/Batch';
import { MaterialService } from '../../services/Material/material.service';
import { Material } from '../../models/Materials';

@Component({
  selector: 'app-new-batch',
  templateUrl: './new-batch.component.html',
  styleUrl: './new-batch.component.css'
})
export class NewBatchComponent implements OnInit{

  batchForm!: FormGroup;
  materials: Material[] = [];

  constructor(
    private materialService: MaterialService,
    private batchService: BatchService,
    private route: ActivatedRoute, 
    private router: Router
  ){}

  ngOnInit(): void {
    this.batchForm = new FormGroup({
      id: new FormControl(0),
      amount: new FormControl(0, [Validators.required]),
      status: new FormControl(0),
      materialId: new FormControl(0, [Validators.required])
    })

    this.materialService.GetMaterials().subscribe((data) => {
      this.materials = data.data;
    });
    
  }

  submit(){
    const batch : Batch = this.batchForm.value;
    const materialId : number = this.batchForm.value.materialId;
    this.batchService.CreateBatch(batch, materialId).subscribe(()=>{
      this.router.navigate([`/batches`]);
    })
  }

  backToBatches(){
    this.router.navigate([`/batches`]);
  }


}
