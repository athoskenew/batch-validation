export interface QualityCharacteristic{
    id? : number;
    name: string;
    description: string;
    type?: number;
    justify: boolean;
    decimalPlaces: number;
    inferiorLimit: number;
    superiorLimit: number;
    materialModelId: number;
}