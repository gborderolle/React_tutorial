//s: https://code.tutsplus.com/creating-pretty-popup-messages-using-sweetalert2--cms-30662t

import Swal from 'sweetalert2';

export default function showSuccess(title: string) {
    const toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 2000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer);
            toast.addEventListener('mouseleave', Swal.resumeTimer);
        },
    });

    toast.fire({
        icon: 'success',
        title: title,
        position: 'center'
    });
}
