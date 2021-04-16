<template>
       <div>
        <div v-if="errors" class="has-error"> {{ [errors] }}</div>
        <div v-if="responseMessage" class="has-error"> {{ responseMessage }}</div>
           <form @submit="checkForm"  method="post">
              <div class="p-5" id="vertical-form">
                <div class="preview">
                    <div class="row">
                            
                            <input  class="form-control" name="companyCode" v-model="postBody.companyCode" placeholder="company code" />
                           
                            
                           <input  class="form-control" name="companyName " v-model="postBody.companyName " placeholder="company name"  />
                       
                          
                            <input class="form-control" name="companyAddress" v-model="postBody.companyAddress" placeholder="company address" />
                       
                   </div>
                   <br/>
                   <div class="row">
                            <input  type="text" class="form-control" name="companyType" v-model="postBody.companyType" placeholder="company type"  />
                  
                   </div>
                    <br/>
                    <div v-if="canProcess" role="group">
                           <button class="btn btn-submit btn-primary" v-on:click="checkForm" type="submit">{{submitorUpdate}}</button>
                    </div>
                     
                </div>
              </div>
              
           </form>
    </div>
				
</template>
<script>
export default{
     data() {
        return {
            errors: null,
            responseMessage:'',
            submitorUpdate : 'Submit',
            canProcess : true,
            postBody: {
                companyCode:'',
                companyName:'',
                companyAddress:'',
                companyType:''
            }
        }
        },
        watch: {
            '$store.state.objectToUpdate': function (newVal, oldVal) {
                this.postBody.companyCode = this.$store.state.objectToUpdate.companyCode,
                this.postBody.companyName= this.$store.state.objectToUpdate.companyName,
                this.postBody.companyAddress = this.$store.state.objectToUpdate.companyAddress,
                this.postBody.companyType = this.$store.state.objectToUpdate.companyType
                this.submitorUpdate = 'Update';

            }
        },
        methods: {
            checkForm: function (e) {
              
                if (this.postBody.companyCode && this.postBody.companyName && this.postBody.companyAddress && this.postBody.companyType) {
                    e.preventDefault();
                    this.canProcess = false;
                    this.postPost();
                }
                else {

                    this.errors = [];
                    this.errors.push('Supply all the required field');
                }
            },
            postPost() {
                if (this.submitorUpdate == 'Submit') {
                    axios.post(`/api/st_stksystem/`, this.postBody)
                        .then(response => {
                            this.responseMessage = response.data.responseDescription; 
                            this.canProcess = true;
                            if (response.data.responseCode == '200') {
                                this.postBody.companyCode = '';
                                this.postBody.companyName='';
                                this.postBody.companyAddress='';
                                this.postBody.companyType='';
                                this.$store.state.objectToUpdate = "create";
                            }
                        })
                        .catch(e => {
                            this.errors.push(e)
                        });
                }
                if (this.submitorUpdate == 'Update') {
                    alert(this.postBody.companyCode);
                    axios.put(`/api/st_stksystem/`, this.postBody)
                        .then(response => {
                            this.responseMessage = response.data.responseDescription; this.canProcess = true;
                            if (response.data.responseCode == '200') {
                                this.submitorUpdate = 'Submit'
                                 this.postBody.companyCode = '';
                                this.postBody.companyName='';
                                this.postBody.companyAddress='';
                                this.postBody.companyType='';
                                this.$store.state.objectToUpdate = "update";
                            }
                        })
                        .catch(e => {
                            this.errors.push(e)
                        });
                }
            }
        },
        computed: {
            setter() {
                let objecttoedit = this.$store.state.objectToUpdate;
                if (objecttoedit.companyCode) {
                     this.postBody.companyCode = objecttoedit.companyCode;
                     this.postBody.companyName=objecttoedit.companyName;
                     this.postBody.companyAddress=objecttoedit.companyAddress;
                     this.postBody.companyType=objecttoedit.companyType;  
                }
            }
        }

};
</script>