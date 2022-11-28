<template>
    <section>        
        <div>            
            <table class="table table-hover" style="text-align: center; vertical-align: center;">
                <thead>
                    <tr>
                        <th @click="sort('id')" style="width: 60px"># <SortUpSymbol v-show="ascending && sortColumn === 'id'"/> <SortDownSymbol v-show="!ascending && sortColumn === 'id'"/></th>
                        <th @click="sort('firstname')" >Όνομα <SortUpSymbol v-if="ascending && sortColumn === 'firstname'"/> <SortDownSymbol v-if="!ascending && sortColumn === 'firstname'"/></th>
                        <th @click="sort('surname')" >Επώνυμο <SortUpSymbol v-if="ascending && sortColumn === 'surname'"/> <SortDownSymbol v-if="!ascending && sortColumn === 'surname'"/></th>
                        <th @click="sort('contactPhone')" >Τηλέφωνο Επικοινωνίας <SortUpSymbol v-if="ascending && sortColumn === 'contactPhone'"/> <SortDownSymbol v-if="!ascending && sortColumn === 'contactPhone'"/></th>
                        <th @click="sort('address')" >Διεύθυνση Κατοικίας <SortUpSymbol v-if="ascending && sortColumn === 'address'"/> <SortDownSymbol v-if="!ascending && sortColumn === 'address'"/></th>
                        <th @click="sort('email')" >Email <SortUpSymbol v-if="ascending && sortColumn === 'email'"/> <SortDownSymbol v-if="!ascending && sortColumn === 'email'"/></th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <tr :key="index" v-for="(customer, index) in this.customers">
                        <td style="justify-content: center; vertical-align: middle;">
                            {{ customer.id }}
                        </td>
                        <td style="justify-content: center; vertical-align: middle;">
                            <div v-if="customer.isEdited === true">
                                <input class="form-control" v-model="this.editedCustomer.firstname" />
                            </div>
                            <label v-else>
                                {{ customer.firstname }}
                            </label>
                        </td>
                        <td style="justify-content: center; vertical-align: middle;">
                            <div v-if="customer.isEdited === true">
                                <input class="form-control" v-model="this.editedCustomer.surname" />
                            </div>
                            <label v-else>
                                {{ customer.surname }}
                            </label>
                        </td>
                        <td style="justify-content: center; vertical-align: middle;">
                            <div v-if="customer.isEdited === true">
                                <input class="form-control" v-model="this.editedCustomer.contactPhone" />
                            </div>
                            <label v-else>
                                {{ customer.contactPhone }}
                            </label>
                        </td>
                        <td style="justify-content: center; vertical-align: middle;">
                            <div v-if="customer.isEdited === true">
                                <input class="form-control" v-model="this.editedCustomer.address" />
                            </div>
                            <label v-else>
                                {{ customer.address }}
                            </label>
                        </td>
                        <td style="justify-content: center; vertical-align: middle;">
                            <div v-if="customer.isEdited === true">
                                <input class="form-control" v-model="this.editedCustomer.email" />
                            </div>
                            <label v-else style="vertical-align: bottom;">
                                {{ customer.email }}
                            </label>
                        </td>
                        <td>
                            <div v-if="customer.isEdited === true" style="padding: 2px">
                                <CustomerDone @click="editCustomer(index)" />
                                <div style="padding: 1px"></div>
                                <CustomerClose @click="cancelEdit(customer)"/>
                            </div>
                            <div v-else style="padding: 2px">
                                <CustomerEdit @click="toggleEdit(customer)" :disabled="isARowOnEdit" />
                            </div>
                            <CustomerDelete @click="deleteCustomer(customer)"/>
                        </td>  
                    </tr>
                </tbody>                  
            </table>
        </div>
    </section>
</template>

<script>
    import axios from 'axios';
    import CustomerDelete from './CustomerDelete.vue';
    import CustomerEdit from './CustomerEdit.vue';
    import CustomerDone from './CustomerDone.vue';
    import CustomerClose from './CustomerClose.vue';
    import SortDownSymbol from './SortDownSymbol.vue';
    import SortUpSymbol from './SortUpSymbol.vue';

    export default {
        name: 'CustomerTable',  
        components: {
            CustomerDelete,
            CustomerEdit,
            CustomerDone,
            CustomerClose,
            SortDownSymbol,
            SortUpSymbol        
        },
        data() {
            return {
                customers: [],
                ascending: true,
                editedCustomer: [],
                deletedCustomer: [],
                isARowOnEdit: Boolean,
                sortColumn: 'id'
            };
        },
        created() {
            this.getAllCustomers()
            this.isARowOnEdit = false;
        },
        methods: { 
            getAllCustomers() {
                axios.get('https://localhost:7125/api/Customer/GetAll')
                .then(response => {
                    console.log(response.data.length);
                    for (var i=0; i < response.data.length; i++) {
                        var customerWithEdit = response.data[i];
                        customerWithEdit.isEdited = false;
                        this.customers.push(customerWithEdit);
                    }
                });
            },
            
            deleteCustomer(customer) { 
                if(confirm('Θέλετε να διαγράαψετε τον χρήστη ' + customer.firstname + " " + customer.surname + ';'))
                {
                    axios.delete('https://localhost:7125/api/Customer/',
                        {data: {id: customer.id}}
                    )
                    .then(response => {                        
                        if(response.status === 200)
                        {
                            this.customers = this.customers.filter(e  => e.id !== customer.id);
                        }
                    }); 
                }                                   
            },
            toggleEdit(customer) {
                customer.isEdited = !customer.isEdited;
                this.isARowOnEdit = !this.isARowOnEdit;
                this.editedCustomer = Object.assign({}, customer);
            },
            cancelEdit(customer) {
                customer.isEdited = false;
                this.isARowOnEdit = !this.isARowOnEdit;
            },
            editCustomer(index) {
                axios.put("https://localhost:7125/api/Customer/",
                    {
                        id: this.editedCustomer.id,
                        firstname: this.editedCustomer.firstname,
                        surname: this.editedCustomer.surname,
                        contactPhone: this.editedCustomer.contactPhone,
                        address: this.editedCustomer.address,
                        email: this.editedCustomer.email                        
                    }                    
                )
                .then(()=> {
                    this.customers[index] = Object.assign({}, this.editedCustomer);
                    this.customers[index].isEdited = !this.customers[index].isEdited;
                    this.isARowOnEdit = !this.isARowOnEdit
                    alert("Ο πελάτης " + this.editedCustomer.firstname + " " + this.editedCustomer.surname + " ανανώθηκε επιτυχώς.")
                });
                
            },
            sort(column) {    
                if(this.sortColumn === column){
                    this.ascending = !this.ascending;
                }else{
                    this.ascending = true;
                    this.sortColumn = column;
                }                
                    console.log(this.ascending);
                this.customers.sort((a,b) => {
                    if(a[column] > b[column]){
                        return this.ascending ? 1 : -1
                    }
                    else if (a[column] < b[column])
                    {
                        return  this.ascending ? -1 : 1;
                    }
                    return 0;
                })
            }
        },                  
    }
</script>

<style scoped>
.td{
    text-align: center;
    vertical-align: center;
}
</style>