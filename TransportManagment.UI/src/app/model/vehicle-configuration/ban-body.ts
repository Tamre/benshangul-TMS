export interface BanBodyGetDto {
    id: number;
    isActive:Boolean;
    name: string;
    localName: string;
    //code: string;
    banBodyCategory: string;
    createdById: string;
    
}
export interface BanBodyPostDto {
    //id: number;
    name: string;
    localName: string;
    //code: string;
    banBodyCategory: string;
    createdById: string;
    isActive:Boolean;
}