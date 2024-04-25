import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import Swal from "sweetalert2";



export function successToast(message:string){
Swal.fire({
    title: message,
    icon: 'success',
    timer: 2000,
    timerProgressBar: true,
    willClose: () => {
      clearInterval(timerInterval);
    },
  }).then((result) => {
    if (result.dismiss === Swal.DismissReason.timer) {
    }
  });
  let timerInterval: any;
}