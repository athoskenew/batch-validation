import { Component, OnInit } from '@angular/core';
import { Batch } from '../../models/Batch';
import { ActivatedRoute, Router } from '@angular/router';
import { BatchService } from '../../services/Batch/batch.service';
import { MaterialService } from '../../services/Material/material.service';
import { Material } from '../../models/Materials';
import { Observable, map } from 'rxjs';

@Component({
  selector: 'app-batches',
  templateUrl: './batches.component.html',
  styleUrl: './batches.component.css'
})
export class BatchesComponent implements OnInit{

  batches: Batch[] = [];
  materials: Material[] = [];

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

    this.materialService.GetMaterials().subscribe((data) => {
      this.materials = data.data;
    });
    
  }

  navigateToNewBatch(): void {
    this.router.navigate(['/new-batch']);
  }

  deleteBatch(batchId: number){
    this.batchService.DeleteBatch(batchId).subscribe(()=>{
      window.location.reload();
    })
  }

  getMaterialName(materialId: number): string {
    const material = this.materials.find(material => material.id === materialId);
    return material ? material.name : 'Error';
}
  
}
