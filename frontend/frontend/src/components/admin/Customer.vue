<template>
    <div>
        <!-- <h1>footers</h1> -->
        <main class="app-content">
            <div class="app-title">
                <ul class="app-breadcrumb breadcrumb side">
                    <li class="breadcrumb-item active"><a href="#"><b>Danh sách khách hàng</b></a></li>
                </ul>
                <div id="clock"></div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="tile">
                        <div class="tile-body">

                            <div class="row element-button">
                                <div class="col-sm-2">

                                    <!-- <a class="btn btn-add btn-sm" href="form-add-nhan-vien.html" title="Thêm"><i
                                            class="fas fa-plus"></i> -->
                                    <button class="btn btn-success" @click="onCreateClick()">Create</button>
                                </div>

                                <div class="col-sm-2">
                                    <a class="btn btn-delete btn-sm" type="button" title="Xóa"
                                        onclick="myFunction(this)"><i class="fas fa-trash-alt"></i> Xóa tất cả </a>
                                </div>
                            </div>
                            <table class="table table-hover table-bordered js-copytextarea" cellpadding="0"
                                cellspacing="0" border="0" id="sampleTable">
                                <thead>
                                    <tr>
                                        <th width="10"><input width="10" type="checkbox" id="all"></th>
                                        <th>ID nhân viên</th>
                                        <th width="150">Họ và tên</th>
                                        <th width="20">Ảnh thẻ</th>
                                        <th width="300">Địa chỉ</th>
                                        <th>Ngày sinh</th>
                                        <th>Giới tính</th>
                                        <th>SĐT</th>
                                        <th>Chức vụ</th>
                                        <th width="100">Tính năng</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="p in productData" :key="p.id">
                                        <th width="10"><input type="checkbox" id="all"></th>
                                        <td>{{ p.id }}</td>
                                        <td>{{ p.className }}</td>
                                        <td><img :src="p.imageProduct" width="80"></td>
                                        <td>{{ p.price }}</td>
                                        <td>{{ p.barCode }}</td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <div class="btn-group" role="group" aria-label="Basic example">
                                                <button type="button" class="btn btn-warning"
                                                    @click="onUpdateClick(p)">Update</button>
                                                <button type="button" class="btn btn-danger">Delete</button>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                                <div class="khoi-phan-trang">
                                    <nav aria-label="Page navigation example">
                                        <ul class="pagination">
                                            <li class="page-item">
                                                <a class="page-link" href="#" aria-label="Previous"
                                                    @click="previousPage">
                                                    <span aria-hidden="true">&laquo;</span>
                                                </a>
                                            </li>
                                            <li class="page-item" v-for="page in totalPages" :key="page">
                                                <a class="page-link" href="#" @click="changePage(page)">{{ page }}</a>
                                            </li>
                                            <li class="page-item">
                                                <a class="page-link" href="#" aria-label="Next" @click="nextPage">
                                                    <span aria-hidden="true">&raquo;</span>
                                                </a>
                                            </li>
                                        </ul>
                                    </nav>
                                </div>
                            </table>
                        </div>
                        <div class="modal fade" ref="productModal" id="productModal" tabindex="-1" role="dialog"
                            aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Create New Product</h5>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal"
                                            aria-label="Close">
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <form>
                                            <div class="form-group">
                                                <label for="recipient-name" class="col-form-label">Product Name:</label>
                                                <input type="text" class="form-control" id="recipient-name"
                                                    v-model="currentProduct.className">
                                            </div>
                                            <!-- <div class="form-group">
                                                <label for="imageProduct" class="col-form-label">Product Image:</label>
                                                <input type="file" class="form-control" id="imageProduct"
                                                    @change="onFileChange">
                                            </div>
                                            <div class="form-group">
                                                <label for="recipient-name" class="col-form-label">Price:</label>
                                                <input type="number" class="form-control" id="recipient-name"
                                                    v-model="currentProduct.price">
                                            </div>
                                            <div class="form-group">
                                                <label for="recipient-name" class="col-form-label">Bar Code:</label>
                                                <input type="text" class="form-control" id="recipient-name"
                                                    v-model="currentProduct.barCode">
                                            </div> -->
                                        </form>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary"
                                            data-dismiss="modal">Close</button>
                                        <button type="button" class="btn btn-primary"
                                            @click="onSaveClick()">Save</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>

        <!--
  MODAL
-->
        <div class="modal fade" id="ModalUP" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static"
            data-keyboard="false">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">

                    <div class="modal-body">
                        <div class="row">
                            <div class="form-group  col-md-12">
                                <span class="thong-tin-thanh-toan">
                                    <h5>Chỉnh sửa thông tin nhân viên cơ bản</h5>
                                </span>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-md-6">
                                <label class="control-label">ID nhân viên</label>
                                <input class="form-control" type="text" required value="#CD2187" disabled>
                            </div>
                            <div class="form-group col-md-6">
                                <label class="control-label">Họ và tên</label>
                                <input class="form-control" type="text" required value="Võ Trường">
                            </div>
                            <div class="form-group  col-md-6">
                                <label class="control-label">Số điện thoại</label>
                                <input class="form-control" type="number" required value="09267312388">
                            </div>
                            <div class="form-group col-md-6">
                                <label class="control-label">Địa chỉ email</label>
                                <input class="form-control" type="text" required value="truong.vd2000@gmail.com">
                            </div>
                            <div class="form-group col-md-6">
                                <label class="control-label">Ngày sinh</label>
                                <input class="form-control" type="date" value="15/03/2000">
                            </div>
                            <div class="form-group  col-md-6">
                                <label for="exampleSelect1" class="control-label">Chức vụ</label>
                                <select class="form-control" id="exampleSelect1">
                                    <option>Bán hàng</option>
                                    <option>Tư vấn</option>
                                    <option>Dịch vụ</option>
                                    <option>Thu Ngân</option>
                                    <option>Quản kho</option>
                                    <option>Bảo trì</option>
                                    <option>Kiểm hàng</option>
                                    <option>Bảo vệ</option>
                                    <option>Tạp vụ</option>
                                </select>
                            </div>
                        </div>
                        <!-- <BR> -->
                        <a href="#" style="    float: right;
        font-weight: 600;
        color: #ea0000;">Chỉnh sửa nâng cao</a>
                        <!-- <BR> -->
                        <!-- <BR> -->
                        <div>
                            <button class="btn btn-save" type="button">Lưu lại</button>
                            <a class="btn btn-cancel" data-dismiss="modal" href="#">Hủy bỏ</a>
                        </div>

                        <!-- <BR> -->
                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>
        <!--
  MODAL
-->
    </div>
</template>

<script>
import axios from 'axios';
import { Modal } from 'bootstrap';
import { toast } from 'vue3-toastify';

import 'vue3-toastify/dist/index.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
export default {
    name: 'EmployeeCustomer',

    // components: {
    //     Modal, toast
    // },
    setup() {
        const success = () => {
            toast("Success !", {
                autoClose: 1000,
                type: "success"
            });
        }
        return { success };
    },
    data() {
        return {
            productData: [],
            productModal: null,
            currentProduct: {
                id: 0,
                className: "Name",

            },
            searchKeyword: '',
            currentPage: 1, // Trang hiện tại
            pageSize: 6,   // Kích thước trang (số lượng sản phẩm trên mỗi trang)
            totalItems: 0,  // Tổng số sản phẩm
            totalPages: 0,
        }
    },
    methods: {
        loadProductData() {
            var url = process.env.VUE_APP_BASE_URL + `Class/GetAll`;
            axios.get(url).then((response) => {
                console.log(response);
                //this.productData = response.data;
                this.totalItems = response.data.length; // Số lượng sản phẩm trong dữ liệu nhận được
                this.totalPages = Math.floor(this.totalItems / this.pageSize);
                if (this.totalItems % this.pageSize !== 0) {
                    this.totalPages++; // Nếu còn dư sản phẩm, tăng totalPages lên 1
                }

                let startIndex = (this.currentPage - 1) * this.pageSize;
                let endIndex = this.currentPage * this.pageSize;

                // Cắt lát productData để chỉ lấy số lượng sản phẩm tương ứng với pageSize
                this.productData = response.data.slice(startIndex, endIndex);
                // Nếu số lượng sản phẩm vượt quá 10, tăng số trang lên 1

            }).catch((error) => {
                console.log(error.response);
            })
        },

        changePage(page) {
            this.currentPage = page;
            this.loadProductData();
        },
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
                this.loadProductData();
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
                this.loadProductData();
            }
        },
        onCreateClick() {
            this.currentProduct = {
                id: 0,
                className: "Name",

            }
            this.productModal.show();
        },
        onUpdateClick(p) {
            this.currentProduct = Object.assign({}, p);// clone d
            this.productModal.show();
        },
        onSaveClick() {
            if (this.currentProduct.id == 0) {
                var url = process.env.VUE_APP_BASE_URL + `Class/Create`;

                // Lấy token từ local storage
                const token = localStorage.getItem('token');

                axios.post(url, this.currentProduct, {
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }
                })
                    .then((response) => {
                        console.log(response.data);

                        // Hiển thị thông báo thành công
                        this.success();

                        // Ẩn modal
                        this.productModal.hide();

                        // Tải lại dữ liệu sản phẩm
                        this.loadProductData();
                    })
                    .catch((error) => {
                        if (error.response && error.response.data) {
                            console.log(error.response.data);
                            // Xử lý lỗi ở đây
                        } else {
                            console.log('Lỗi không xác định:', error);
                        }
                    });
            }
            else {
                var url1 = process.env.VUE_APP_BASE_URL + `Class/Update`;

                // Lấy token từ local storage
                const token = localStorage.getItem('token');
                axios.put(url1, this.currentProduct, {
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }
                })
                    .then((response) => {
                        console.log(response.data);
                        // Hiển thị thông báo thành công
                        this.success();
                        // Ẩn modal
                        this.productModal.hide();
                        // Tải lại dữ liệu sản phẩm
                        this.loadProductData();
                    })
                    .catch((error) => {
                        console.log('Lỗi Axios:', error);
                        if (error.response) {
                            console.log('Phản hồi từ server:', error.response.data);
                            if (error.response.status === 401) {
                                console.log('Token hết hạn hoặc không hợp lệ.');
                                // Xử lý token hết hạn ở đây
                            }
                        }
                    });

            }

        },
        logout() {
            // Xử lý đăng xuất ở đây
            // Ví dụ: xóa token khỏi Local Storage và chuyển hướng đến trang đăng nhập
            localStorage.removeItem('token');
            this.$router.push('/login');
        },
        onFileChange(event) {
            const file = event.target.files[0];
            if (file) {
                // Kiểm tra phần mở rộng của file
                const validExtensions = ['.png', '.jpg', '.jpeg'];
                const fileName = file.name;
                const fileExtension = fileName.substring(fileName.lastIndexOf('.')).toLowerCase();

                if (!validExtensions.includes(fileExtension)) {
                    alert('Vui lòng chọn một file ảnh có định dạng .png, .jpg hoặc .jpeg!');
                    return;
                }

                const reader = new FileReader();
                reader.onload = (e) => {
                    this.currentProduct.imageProduct = e.target.result;
                };
                reader.readAsDataURL(file);
            }
        },
        onSubmit() {
            var url = process.env.VUE_APP_BASE_URL + `/Products/fullFilter`;
            var requestData = {
                filterParams: [
                    {
                        colName: "productName",
                        _operator: "like",
                        value: this.searchKeyword
                    }
                ],
                index: 1,
                size: 10,
                sortAsc: true,
                sortCol: "productName"
            };

            axios.post(url, requestData)
                .then(response => {
                    this.productData = response.data;
                    this.totalItems = this.productData.length; // Số lượng sản phẩm trong dữ liệu nhận được
                    this.totalPages = Math.ceil(this.totalItems / this.pageSize);
                    console.log(this.productData);
                })
                .catch(error => {
                    console.error('Lỗi khi tìm kiếm sản phẩm:', error);
                });
        }

    },
    mounted() {
        this.loadProductData();
        console.log(this.totalPages);
        //load Modal
        this.productModal = new Modal(this.$refs.productModal);
    }
}
</script>