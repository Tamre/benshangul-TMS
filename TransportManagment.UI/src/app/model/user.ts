export interface User {
    username: string ;
    password: string ;
    macAddress:String
}
export interface UserView {
    email : string ; 
    userId : string ;
    id:string;
    userName:string ;
    userTypeId: number;
    userType: string;
}

export interface Token {
    token :string ;
}
export interface ChangePasswordModel{
    UserId : string
    CurrentPassword :string
    NewPassword :string
   }

export interface UserList {
    id :string;
    employeeId :string
    name : string
    userName : string
    status : string
    imagePath : string   
    department : string
    position : string   
    email : string   
    phoneNumber : string
    roles : string[]
}
export interface UserPost {
    employeeId:string,
    userName :string,
    password:string
 
}

export interface DeviceRequestDto {

    PCNAme:string
    IpAddress:string
    MACAddress:string
    CreatedById:string
}

export interface DeviceGetDto {
    id?:number
    requesterUser? :string 
    approverUser?: string
    isActive?:boolean
    pcnAme?:string 
    ipAddress? :string
    macAddress?:String
    approverId?:string
    approvedFor?:string
    createdById?:string

}
