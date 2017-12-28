/**
 * Created by NghiaNM on 7/4/2016.
 */
var patientCode = qs['patient_code'];
var token = qs['token'];
var langs = (qs['language'] != null ) ? qs['language'] : 'ja';
if (langs) {
    moment.locale(langs);
} else {
    moment.locale('ja');
}
/**
 * Format datetime by language
 * @param data
 * @returns {*}
 */
function formatDate(data) {
    switch (langs) {
        case 'en':
            data = moment(data).format(formatEn);
            break;
        case 'vi':
            data = moment(data).format(formatVi);
            break;
        default:
            data = moment(data).format(formatJa);
    }
    return data;
}

/**
 * Get data
 * @param url
 * @param params
 */
function loadData(url, params) {
    if (!token) {
        $('.contentpanel').hide();
        return;
    }

    //    GET data from server api via jQuery ajax
    $.ajax({
        url: url + params,
        method: "GET",
        headers: {
            'token': token
        },
        success: function (res, status) {
            /*If patient does not have any patient survey, show message else bind data normally*/
            if (res.status == 1) {
                /* reload relate list*/
                $('.list-normal').html('');
                /*If patient survey does not answered, show message else bind data normally*/
                if (res.data.status_flg == 1) {
                    /*Clear displayed data*/
                    $('h2').html('');
                    $('#patient-code').html('');
                    $('#patient-name').html('');
                    $('#visit-date').html('');
                    $('#answer-date').html('');
                    $('#department').html('');
                    $('#hospital').html('');
                    $('#address').html('');
                    $('.smalltext').html('');
                    $('.servey-view-area').html('');
                    $('.contentpanel .container-fluid .row .col-md-8 .panel').show();
                    $('.contentpanel .container-fluid .row .message-body').html('');
                    $('.contentpanel .container-fluid .row .message-body').hide();
                    /* Append data response*/
                    var titleE = (res.data.survey_title != null) ? res.data.survey_title.toString() : '';
                    var patientCode = (res.data.patient_code != null) ? res.data.patient_code.toString() : '';
                    var patientName = (res.data.patient_name != null) ? res.data.patient_name.toString() : '';
                    var department = (res.data.department_name != null) ? res.data.department_name.toString() : '';
                    var hospital = (res.data.hospital_info.hosp_name != null) ? res.data.hospital_info.hosp_name : '';
                    var address = (res.data.hospital_info.address != null) ? res.data.hospital_info.address : '';
                    var visitDate = formatDate(res.data.reservation_date);
                    var answerDate = formatDate(res.data.answer_date);
                    $('h2').append(titleE);
                    $('#patient-code').append(patientCode);
                    $('#patient-name').append(patientName);
                    $('#visit-date').append(visitDate);
                    $('#answer-date').append(answerDate);
                    $('#department').append(department);
                    $('#hospital').append(hospital);
                    $('#address').append(address);
                    var desE = (res.data.description != null) ? res.data.description.toString() : '';
                    $('.smalltext').append(desE);
                    $.each(res.data.group, function (index, group) {
                        var groupE = $(nano("<section><h3>{title}</h3><hr class=\"lighters\"></section>", group));
                        $.each(group.question, function (index, question) {
                            var questionE = $(nano("<section><h5><span class=\"number\">" + (index + 1) + ". </span>{question_content}</h5><div class=\"list-answers\"><div class=\"row\"></div></div></section>", question));
                            var answerContainer = questionE.find(".list-answers > .row").first();
                            if (question.question_type != 2) {
                                $.each(question.answer, function (index, answer) {
                                    var answerE = $(nano("<div class=\"col-sm-6\">" +
                                        "<p>" +
                                        "<label class=\"" + (question.question_type == 0 ? 'rdiobox' : 'ckbox') + "\">" +
                                        "<input type=\"" + (question.question_type == 0 ? 'radio' : 'checkbox') + "\" disabled=\"disable\" " + (answer.is_selected == 1 ? 'checked' : '') + ">" +
                                        "<span>{content}</span>" +
                                        "</label>" +
                                        "</p>" +
                                        "</div>", answer));
                                    answerContainer.append(answerE);
                                });
                            }
                            else {
                                if(question.input_text == null){
                                    question.input_text = '___________________';
                                }
                                var inputAnsE =  '<div class=\"col-sm-6\"><textarea cols="50" rows="2" disabled="disabled">' + question.input_text + '</textarea></div>';
                                answerContainer.append(inputAnsE);
                            }
                            if (question.has_other_answer == 1) {
                                if(question.has_other_text == null){
                                    question.has_other_text = '___________________';
                                }
                                var otherAnsE = eval("lang." + langs)["Other"] + ': <label class="rdiobox"><span>' + question.has_other_text + '</span></label>';
                                answerContainer.append(otherAnsE);
                            }
                            groupE.append(questionE);
                        })
                        $('.servey-view-area').append(groupE);
                    });
                } else {
                    $('.contentpanel .container-fluid .row .col-md-8 .panel').hide();
                    $('.contentpanel .container-fluid .row .message-body').show();
                    $('.contentpanel .container-fluid .row .message-body').html(eval('lang.' + langs)['Patient does not answer this survey']);
                }

                /* If patient survey does not have relate survey, show message else bind relate data*/
                if (res.data.relate_survey.has_more == true) {
                    $.each(res.data.relate_survey.relate_list, function (index, list) {
                        var relate = '<li><a href="#" onclick="return loadData(\'' + UrlById + '\',\'' + list.survey_patient_id + '\');">[' + list.department_name + "]" + formatDate(list.answer_date) + "</a></li>";
                        $('.list-normal').append(relate);
                    })
                } else {
                    $('.list-normal').html('');
                    $('.list-normal').append(eval('lang.' + langs)['Do not have survey on the past']);
                }
            } else {
                $('.contentpanel .container-fluid .row .col-md-8').hide();
                $('.contentpanel .container-fluid .row .col-md-4').hide();
                $('.contentpanel .container-fluid .row .message').show();
                $('.contentpanel .container-fluid .row .message').html(eval('lang.' + langs)['This patient does not have any answered survey']);
            }
        }
    });
}
/* First, load patient survey by patient code*/
loadData(UrlByCode, patientCode);

window.toggleRelatedSurvey = function (){
    $('#related-survey').toggle();
};

/* Display text by language */
$(document).ready(function () {
    $('#page-title').html(eval('lang.' + langs)['Heath survey of patient']);
    $('#patient-code-title').html(eval('lang.' + langs)['Patient code']);
    $('#patient-name-title').html(eval('lang.' + langs)['Patient name']);
    $('#patient-visit-title').html(eval('lang.' + langs)['Visit date']);
    $('#patient-answer-title').html(eval('lang.' + langs)['Answered date']);
    $('#hospital-title').html(eval('lang.' + langs)['Hospital']);
    $('#address-title').html(eval('lang.' + langs)['Address']);
    $('#contact-title').html(eval('lang.' + langs)['Contact']);
    $('#department-title').html(eval('lang.' + langs)['Department']);
    $('#description-title').html(eval('lang.' + langs)['Survey description']);
    $('#relate-title').html(eval('lang.' + langs)['Related health survey']);
});

