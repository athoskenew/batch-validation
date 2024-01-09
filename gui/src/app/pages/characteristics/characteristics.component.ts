import { Component, OnInit } from '@angular/core';
import { QualityCharacteristicService } from '../../services/QualityCharacteristic/quality-characteristic.service';
import { ActivatedRoute, Router } from '@angular/router';
import { QualityCharacteristic } from '../../models/QualityCharacteristic';

@Component({
  selector: 'app-characteristics',
  templateUrl: './characteristics.component.html',
  styleUrl: './characteristics.component.css'
})
export class CharacteristicsComponent implements OnInit{

  characteristics: QualityCharacteristic[] = [];
  id!: number;

  displayedColumns = ['Id', 'Nome', 'Descricao', 'Tipo', 'LimiteInferior', 'LimiteSuperior', 'Justificativa', 'Excluir']

  constructor(
    private qualityCharacteristicsService: QualityCharacteristicService, 
    private route: ActivatedRoute,
    private router: Router){}


  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.qualityCharacteristicsService.GetCharacteristics(this.id).subscribe(data =>{
      const responseData = data.data;
      this.characteristics = responseData;
    })
    
  }

  navigateToNewCharacteristic(): void {
    this.router.navigate(['/new-characteristic', this.id]);
  }

  deleteCharacteristic(characteristicId: number){
    this.qualityCharacteristicsService.DeleteCharacteristic(this.id, characteristicId).subscribe(data =>{
      window.location.reload();
    })

}
}
