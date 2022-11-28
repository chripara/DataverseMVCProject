<template>
    <div class="d-flex justify-content-center bd-highlight" style="margin-left: -210px">
        <div class=" bd-highlight" style="justify-items: flex-start;">            
            <div class="form-floating">
                <input type="text" class="form-control" style="width: 200%;" id="floatingFirstname" v-model="newCustomer.firstname" placeholder="name@example.com">
                <label for="floatingFirstname">Όνομα: </label>
            </div>  
            <br/>
            <div class="form-floating">
                <input type="text" class="form-control" style="width: 200%;" id="floatingSurname" v-model="newCustomer.surname" placeholder="name@example.com">
                <label for="floatingEmail">Επώνυμο: </label>
            </div>  
            <br/>
            <div class="form-floating">
                <input type="tel" class="form-control" style="width: 200%;" id="floatingEmail" v-model="newCustomer.contactPhone" placeholder="name@example.com">
                <label for="floatingContactPhone">Τηλέφωνο Επικοινωνίας: </label>
            </div>  
            <br/>
            <div class="form-floating">
                <input type="text" class="form-control" style="width: 200%;" id="floatingAddress" v-model="newCustomer.address" placeholder="name@example.com">
                <label for="floatingAddress">Διεύθυνση Κατοικίας: </label>
            </div>  
            <br/>
            <div class="form-floating">
                <input type="email" class="form-control" style="width: 200%;" id="floatingEmail" v-model="newCustomer.email" placeholder="name@example.com">
                <label for="floatingEmail">Email:</label>
            </div>  
        </div>       
    </div>
    <br/>
    <br/>

    <button @click="createCustomer" class="btn btn-outline-success" >Δημιουργία νέου πελάτη</button>
</template>


<script>
    import axios from 'axios';
        
    export default {
        name: 'NewCustomer',   
        data() {
            return {
                newCustomer:  []
            }
        },        
        props: {
            customers:  []
        },
        create() {
            console.log(this.customer)
        },
        methods: {
            createCustomer(){
                axios.post('https://localhost:7125/api/Customer',
                {                    
                    firstname: this.newCustomer.firstname,
                    surname: this.newCustomer.surname,
                    contactPhone: this.newCustomer.contactPhone,
                    address: this.newCustomer.address,
                    email: this.newCustomer.email 
                })
                .then((response) => {
                    this.newCustomer = [];
                    if(response.status)
                        alert('Ο πελάτης προστέθηκε επιτυχώς!');
                })
                .catch(er => {
                    if(er)
                        alert("Παρακαλώ ελέγξτε ξανά τα στοιχεία που προσθέσατε.");
                });
            }
        }
    }
</script>