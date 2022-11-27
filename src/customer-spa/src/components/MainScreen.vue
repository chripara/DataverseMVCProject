<template>
    <sections>
        <div style="height: 90px">
            <CustomerHeader />           
        </div>
        <div style="float: right">
            <CustomerNew @click="toggleNewCustomer"/>
            <br/>
            <br/>
        </div>
        <div v-if="!newCustomer">
            <NewCustomer />
        </div>
        <div v-else>
            <CustomerTable />
        </div>        
    </sections>    
</template>

<script>
    import CustomerHeader from './CustomerHeader.vue';
    import CustomerTable from '../components/Customer/CustomerTable.vue';
    import CustomerNew from '../components/Customer/CustomerNew.vue';
    import NewCustomer from '../components/Customer/NewCustomer.vue';

    export default {
        name: 'MainScreen',
        components: {
            CustomerHeader,
            CustomerTable,
            CustomerNew,
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
    siteNavigation {
        height: 40%
    }
</style>