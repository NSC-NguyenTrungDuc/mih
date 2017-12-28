$(document).ready(function() {
	$('.hospital-delete').on('click', function(e) {
		var $target = $(e.currentTarget);
		var id = $target.attr('data-id');
		var $dialog = $('#confirmDeleteHospital');
		$dialog.attr('data-id', id);
		$dialog.modal('show');
	});

});

function doDeleteHospital() {
	var hospitalId = $('#confirmDeleteHospital').attr('data-id');
	location.href = '../schedule/delete-hospital?hospitalId=' + hospitalId;
};

$(document).ready(function() {
	$('.department-delete').on('click', function(e) {
		var $target = $(e.currentTarget);
		var id = $target.attr('data-id');
		var juniorFlg = $target.attr('value');
		var $dialog = $('#confirmDeleteDepartment');
		$dialog.attr('data-id', id);
		$dialog.attr('value', juniorFlg);
		$dialog.modal('show');
	});
});

function doDeleteDepartment() {
	var departmentId = $('#confirmDeleteDepartment').attr('data-id');
	location.href = '../schedule/delete-department?deptId=' + departmentId;
};

$(document).ready(function() {
	$('.update-junior-flg-doctor').on('click', function(e) {
		var $target = $(e.currentTarget);
		var id = $target.attr('data-id');
		var juniorFlg = $target.is(':checked');
		var $dialog = $('#confirmUpdateJuniorFlgForDoctor');
		$dialog.attr('data-id', id);
		$dialog.attr('value', juniorFlg);
		$dialog.modal('show');
	});
});

$(document).ready(function() {
	$('.cancle-select').on('click', function(e) {
		var $dialog = $('#confirmUpdateJuniorFlgForDoctor');
		var doctId = $dialog.attr('data-id');
		var isCheck = $('.update-junior-flg-doctor[data-id=' + doctId + ']').is(':checked');
		if(isCheck) {
			$('.update-junior-flg-doctor[data-id=' + doctId + ']').removeAttr('checked');
		} else {
			$('.update-junior-flg-doctor[data-id=' + doctId + ']').prop('checked', 'checked');
		}
	});
});

$(document).ready(function() {
	$('.close').on('click', function(e) {
		var $dialog = $('#confirmUpdateJuniorFlgForDoctor');
		var doctId = $dialog.attr('data-id');
		var isCheck = $('.update-junior-flg-doctor[data-id=' + doctId + ']').is(':checked');
		if(isCheck) {
			$('.update-junior-flg-doctor[data-id=' + doctId + ']').removeAttr('checked');
		} else {
			$('.update-junior-flg-doctor[data-id=' + doctId + ']').prop('checked', 'checked');
		}
	});
});


function doUpdateFlgForDoctor() {
	var doctorId = $('#confirmUpdateJuniorFlgForDoctor').attr('data-id');
	var juniorFlg = $('#confirmUpdateJuniorFlgForDoctor').attr('value');
	location.href = '../schedule/update-junior-flg-doctor?doctorId=' + doctorId + "&juniorFlg=" +juniorFlg;
};

$(document).ready(function() {
	$(".deleteDoctor").click(function(){
		var doctorId = $(this).find("span").html();
		location.href = "../schedule/delete-doctor?doctorId=" + doctorId;
	});
});