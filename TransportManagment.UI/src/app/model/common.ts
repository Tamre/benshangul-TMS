

export interface reponseData {
        success?: boolean,
        message?: string,
        data?:any    
}



export interface GeneralCodeDto {

    generalCode: string
    initialName: string
    pad: number
    currentNumber: number

}

export interface GetStartEndDate{

    fromDate : string
    endDate:string
   
}

export interface IEvoCalanderDto {


    id: string
    name: string
    description: string
    badge: string
    date: string
    type: string
    everyYear: boolean
}


export interface MacAddressServiceDto {
    PCName: string
    MacAddress: string
    IPAddress: string
}

export interface ISettingDropDownsDto {
    id : number 
    name: string
}
export interface IActionDropDownDto {
    id : string 
    name: string
}


export interface PaginatedResponse<T> {
    data: T[];
    metaData: MetaData;
}

export interface MetaData {
    currentPage: number;
    totalPages: number;
    pageSize: number;
    totalCount: number;
    hasPrevious: boolean;
    hasNext: boolean;
}

