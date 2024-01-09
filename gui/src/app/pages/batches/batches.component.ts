import { Component, OnInit } from '@angular/core';
import { Batch } from '../../models/Batch';
import { ActivatedRoute, Router } from '@angular/router';
import { BatchService } from '../../services/Batch/batch.service';
import { MaterialService } from '../../services/Material/material.service';
import { Material } from '../../models/Materials';

@Component({
  selector: 'app-batches',
  templateUrl: './batches.component.html',
  styleUrl: './batches.component.css'
})
export class BatchesComponent implements OnInit{

  batches: Batch[] = [];

  constructor(
    private materialService: MaterialService,
    private batchService: BatchService,
    private route: ActivatedRoute,
    private router: Router
  ){}

  ngOnInit(): void {

    this.batchService.getBatches().subscribe(data =>{
      const responseData = data.data;
      this.batches = responseData;
    })
    
  }

  navigateToNewCharacteristic(): void {
    this.router.navigate(['/new-batch']);
  }

  deleteBatch(batchId: number){
    this.batchService.DeleteBatch(batchId).subscribe(()=>{
      window.location.reload();
    })
  }

  getMaterialName(materialId: number){
    let material: Material;
    this.materialService.GetMaterialById(materialId).subscribe(data =>{
      material = data.data;
      return material.name;
    })
  }
}
