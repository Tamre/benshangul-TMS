export interface FactoryPointGetDto {
    id: number;
    value:Float32Array;
    markId:number;
    createdById: string;
    isActive:Boolean;
}
export interface FactoryPointPostDto {
    value:Float32Array;
    markId:number;
    createdById: string;
    //isActive:Boolean;
}