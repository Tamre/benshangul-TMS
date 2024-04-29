export interface FactoryPointGetDto {
    id: number;
    value:Float32Array;
    
    markName:string;
    createdById: string;
    isActive:Boolean;
}
export interface FactoryPointPostDto {
    value:Float32Array;
    markId:number;
    //markName:string;
    createdById: string;
    //isActive:Boolean;
}
export interface FactoryPointUpdateDto {
    value:Float32Array;
    markId:number;
    markName:string;
    createdById: string;
    //isActive:Boolean;
}