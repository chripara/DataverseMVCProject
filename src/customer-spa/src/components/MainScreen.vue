<template>
    <sections>
        <div style="padding-right: 100px; padding-left: 100px;">
            <div style="height: 90px"  v-if="newCustomer">
                <h2>Πελατολόγιο</h2>           
            </div>
            <div v-else style="height: 90px">
                <h2>Νέος Πελάτης</h2>           
            </div>
            <div style="float: right" >
                <button v-if="newCustomer"  @click="toggleNewCustomer" class="btn btn-outline-info">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus" viewBox="0 0 16 16">
                        <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z"/>
                    </svg>
                    Νέος Πελάτης
                </button>   
                <button v-else  @click="toggleNewCustomer" class="btn btn-outline-info">                
                    Πελατολόγιο
                </button>               
            </div>
            <br/>
            <br/>
                <br/>
            <div v-if="!newCustomer">
                <NewCustomer />
            </div>
            <div v-else>
                <CustomerTable />
            </div>   
        </div>     
    </sections>    
</template>

<script>
    import CustomerTable from '../components/Customer/CustomerTable.vue';
    import NewCustomer from '../components/Customer/NewCustomer.vue';

    export default {
        name: 'MainScreen',
        components: {
            CustomerTable,
            NewCustomer
        },
        create() {
            this.newCustomer = false;
        },
        data() {            
            return {
                newCustomer: Boolean
            }    
        },
        methods: {
            toggleNewCustomer() {
                this.newCustomer = !this.newCustomer;
            }
        }
    }
    
</script>

<style scoped>
.h2{
    display: flex; 
    text-align:'center'; 
    width: 100% 
}
</style>