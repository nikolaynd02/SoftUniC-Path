function validate() {
    let emailElement = document.getElementById('email');
    const pattern = /^([a-z]+@{1}[a-z]+\.{1}[a-z]+)$/;
    emailElement.addEventListener('change', (e) => {
        console.log(e.target);
        if(pattern.test(e.target.value)){
            e.currentTarget.removeAttribute('class');
        }
        else{
            e.currentTarget.classList.add('error');
        }
    })
}