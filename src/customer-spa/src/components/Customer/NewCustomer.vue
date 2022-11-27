<template>
    <div>
        <label for="firstname">Όνομα</label>
        <input type="text" v-model="newCustomer.firstname">

        <label for="surname">Επώνυμο</label>
        <input type="text" v-model="newCustomer.surname">

        <label for="contactPhone">Τηλέφωνο Επικοινωνίας</label>
        <input type="text" v-model="newCustomer.contactPhone">

        <label for="address">Διεύθυνση Κατοικίας</label>
        <input type="text" v-model="newCustomer.address">

        <label for="email">Email</label>
        <input type="text" v-model="newCustomer.email">

        <label>Actions</label>
        <button @click="createCustomer">Create Customer</button>
    </div>
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
            console.log(this.customers)
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
                });
            }
        }
    }
</script>