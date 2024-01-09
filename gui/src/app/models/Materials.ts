import { QualityCharacteristic } from "./QualityCharacteristic";
import { QualityVision } from "./QualityVision";

export interface Material{
    id? : number;
    name: string;
    description: string;
    creationDate?: string;
    materialQualityCharacteristics: QualityCharacteristic;
    materialQualityVision: QualityVision;
}