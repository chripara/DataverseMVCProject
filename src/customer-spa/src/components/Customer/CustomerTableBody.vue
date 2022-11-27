<template>
    <tbody >
        <tr :key="index" v-for="(customer, index) in this.customers">
            <td>
                {{ customer.id }}
            </td>
            <td>
                {{ customer.firstname }}
            </td>
            <td>
                {{ customer.surname }}
            </td>
            <td>
                {{ customer.contactPhone }}
            </td>
            <td>
                {{ customer.address }}
            </td>
            <td>
                {{ customer.email }}
            </td>          
            <td>
                <CustomerEdit/>
                <CustomerDelete @click="deleteCustomer(customer.id)"/>
            </td>  
        </tr>
    </tbody>        
    <!-- <button @click="deleteCustomer(11)" >testdelete</button> -->
</template>

<script>
    import CustomerDelete from './CustomerDelete.vue';
    import CustomerEdit from './CustomerEdit.vue';
    import axios from 'axios';
    
    export default {
        
        name: 'CustomerTableBody',   
        components: {
            CustomerDelete,
            CustomerEdit, 
        },        
        data() {
            return {                
                renderedCustomers: []
            };
        }, 
        props: {
            customers:  []
        },
        create() {
            this.renderedCustomers = this.customers;
            console.log('renderedCustomers');
            console.log(this.renderedCustomers);
        },
        methods: {
            // renderTable() 
            deleteCustomer(id) { 
                console.log(id);
                axios.delete('https://localhost:7125/api/Customer/',
                    {data: {id: id}}
                )
                    .then(response => {
                        console.log(response);
                        if(response.status === 200)
                        {
                            const newCustomers = this.renderedCustomers.filter(e  => e.id !== id);
                            this.renderedCustomers = newCustomers;
                            console.log(this.customers[0]);
                            console.log('renderedCustomers');
                            console.log(this.renderedCustomers);
                        }
                });    
            }
        }    
    }
</script>