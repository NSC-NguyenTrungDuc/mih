package nta.med.kcck.api.adapter.impl;

import java.util.Arrays;
import java.util.List;

import org.springframework.stereotype.Component;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.common.remoting.ServiceExecutionException;
import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.adapter.AbstractAdapter;
import nta.med.core.utils.BeanUtils;
import nta.med.kcck.api.adapter.NuroAdapter;
import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.BookingServiceProto;
import nta.med.kcck.api.rpc.proto.BookingServiceProto.CancelBookingExaminationRequest;
import nta.med.kcck.api.rpc.proto.BookingServiceProto.CancelBookingExaminationResponse;
import nta.med.kcck.api.rpc.proto.BookingServiceProto.ChangeBookingExaminationRequest;
import nta.med.kcck.api.rpc.proto.BookingServiceProto.ChangeBookingExaminationResponse;
import nta.med.kcck.api.rpc.proto.HospitalModelProto;
import nta.med.kcck.api.rpc.proto.HospitalServiceProto;
import nta.med.kcck.api.rpc.proto.PatientModelProto;
import nta.med.kcck.api.rpc.proto.PatientServiceProto;
import nta.med.kcck.api.rpc.proto.PatientServiceProto.SyncReservationRequest;
import nta.med.kcck.api.rpc.proto.PatientServiceProto.SyncReservationResponse;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

/**
 * @author dainguyen.
 */
@Component("nuroAdapter")
public class NuroAdapterImpl extends AbstractAdapter implements NuroAdapter {

    public NuroAdapterImpl() {
        //super(NuroServiceProto.class, NuroServiceProto.getDescriptor());
    	super(Arrays.asList(NuroServiceProto.class, SystemServiceProto.class), NuroServiceProto.getDescriptor());
    }

//    @Override
//    public List<KCCKGetDoctorWorkingTimeInfo> getKCCKGetScheduleDoctorInfo(
//            String hospitalCode, String departmentCode, String examPreDate, String endDate, String doctorCode, String avgTime) {
//        final NuroServiceProto.KCCKAPIGetScheduleDocTorRequest.Builder builder = NuroServiceProto.KCCKAPIGetScheduleDocTorRequest.newBuilder()
//                .setHospCode(hospitalCode)
//                .setDepartment(departmentCode)
//                .setDoctorCode(doctorCode)
//                .setStartDate(examPreDate)
//                .setEndDate(endDate)
//                .setAgvTime(avgTime);
//        NuroServiceProto.KCCKAPIGetScheduleDocTorRequest request = builder.build();
//        final NuroServiceProto.KCCKAPIGetScheduleDocTorResponse response = submit(null, request, 10000L);
//        if (response != null) {
//            List<KCCKGetDoctorWorkingTimeInfo> listResponse = new ArrayList<KCCKGetDoctorWorkingTimeInfo>();
//            List<KCCKGetEnableScheduleDoctorInfo> enableList = new ArrayList<KCCKGetEnableScheduleDoctorInfo>();
//            List<NuroModelProto.KCCKGetScheduleDoctorInfo> list = response.getContentList();
//            for (NuroModelProto.KCCKGetScheduleDoctorInfo item : list) {
//                KCCKGetDoctorWorkingTimeInfo info = new KCCKGetDoctorWorkingTimeInfo(item.getResAmStart(),
//                        item.getResAmEnd(), item.getResPmStart(), item.getResPmEnd(), item.getAvgTime());
//                for (NuroModelProto.KCCKGetEnableScheduleDoctorInfo enable : item.getEnableSlotList()) {
//                    KCCKGetEnableScheduleDoctorInfo enbaleInfo = new KCCKGetEnableScheduleDoctorInfo(enable.getEnableDateSlot(), enable.getEnableTimeSlot());
//                    enableList.add(enbaleInfo);
//                }
//                info.setEnableSlot(enableList);
//                listResponse.add(info);
//            }
//            return listResponse;
//        }
//        return null;
//    }

    @Override
    public HospitalServiceProto.GetDoctorByDepartmentResponse getDoctorByDepartment(RpcApiSession session, HospitalServiceProto.GetDoctorByDepartmentRequest request) {
        HospitalServiceProto.GetDoctorByDepartmentResponse.Builder r = HospitalServiceProto.GetDoctorByDepartmentResponse.newBuilder();

        final NuroServiceProto.KcckApiGetDoctorsRequest.Builder builder = NuroServiceProto.KcckApiGetDoctorsRequest.newBuilder()
                .setHospCode(request.getHospCode())
                .setDepartment(request.getDepartmentCode());
        NuroServiceProto.KcckApiGetDoctorsRequest req = builder.build();
        final NuroServiceProto.KcckApiGetDoctorsResponse response = submit(session, req, 10000L);
        if (response != null) {
            List<NuroModelProto.KcckApiGetDoctorInfo> listResponse = response.getListDoctorList();
            for (NuroModelProto.KcckApiGetDoctorInfo item : listResponse) {
                HospitalModelProto.Doctor.Builder info = HospitalModelProto.Doctor.newBuilder()
                        .setDoctorCode(item.getDoctor()).setDoctorName(item.getDoctorName()).setDoctorGrade(item.getDoctorGrade())
                        .setDepartmentId(item.getDepartmentId()).setDoctorId(item.getDoctorId());
                r.addDoctors(info);
            }
        }
        return r.build();
    }

    @Override
    public HospitalServiceProto.SearchDoctorResponse searchDoctors(RpcApiSession session, HospitalServiceProto.SearchDoctorRequest request) {
        HospitalServiceProto.SearchDoctorResponse.Builder searchResponse = HospitalServiceProto.SearchDoctorResponse.newBuilder();

        final NuroServiceProto.KcckApiSearchDoctorsRequest.Builder builder = NuroServiceProto.KcckApiSearchDoctorsRequest.newBuilder()
        		.setHospCode(request.getHospCode() == null ? "" : request.getHospCode())
		    	.setDepartment(request.getDepartmentCode() == null ? "" : request.getDepartmentCode())
		    	.setStartDate(request.getStartDate() == null ? "" : request.getStartDate())
		    	.setEndDate(request.getEndDate() == null ? "" : request.getEndDate())
		    	.setLocale(request.getLocale() == null ? "" : request.getLocale())
		    	.setReservationDate(request.getReservationDate() == null ? "" : request.getReservationDate())
		    	.setReservationTime(request.getReservationTime() == null ? "" : request.getReservationTime())
		    	.setPageSize(request.getPageSize() == null ? "" : request.getPageSize())
		    	.setPageIndex(request.getPageIndex() == null ? "" : request.getPageIndex());

        NuroServiceProto.KcckApiSearchDoctorsRequest req = builder.build();
        final NuroServiceProto.KcckApiSearchDoctorsResponse response = submit(session, req, 10000L);
        if (response != null) {
            List<NuroModelProto.KcckApiGetDoctorInfo> listResponse = response.getListDoctorList();
            for (NuroModelProto.KcckApiGetDoctorInfo item : listResponse) {
                HospitalModelProto.Doctor.Builder info = HospitalModelProto.Doctor.newBuilder()
                        .setDoctorCode(item.getDoctor())
                        .setDoctorName(item.getDoctorName())
                        .setDoctorGrade(item.getDoctorGrade())
                        .setDepartmentId(item.getDepartmentId())
                        .setDoctorId(item.getDoctorId());
                searchResponse.addDoctors(info);
            }
            searchResponse.setTotalRecords(response.getTotalRecords());
        }
        return searchResponse.build();
    }
    
    @Override
    public BookingServiceProto.BookingExaminationResponse booking(RpcApiSession session, BookingServiceProto.BookingExaminationRequest request) {
        final NuroServiceProto.KcckApiBookingRequest.Builder builder = NuroServiceProto.KcckApiBookingRequest.newBuilder()
                .setHospCode(request.getHospCode())
                .setDepartmentCode(request.getDepartmentCode())
                .setReservationDate(request.getReservationDate())
                .setReservationTime(request.getReservationTime())
                .setPatientType(request.getPatientType())
                .setDoctorCode(request.getDoctorCode())
                .setType(request.getType())
                .setUserId(request.getUserId());
        if (!StringUtils.isEmpty(request.getLocale())) {
            builder.setLocale(request.getLocale());
        }
        if (!StringUtils.isEmpty(request.getPatientCode())) {
            builder.setPatientCode(request.getPatientCode());
        }
        if (StringUtils.isEmpty(request.getPatientCode())) {
            builder.setPatientNameKanji(request.getPatientNameKanji())
                    .setPatientNameKana(request.getPatientNameKana())
                    .setPatientTel(request.getPatientTel())
                    .setPatientEmail(request.getPatientEmail())
                    .setPatientSex(request.getPatientSex())
                    .setPatientBirthday(request.getPatientBirthday());
        }

        final NuroServiceProto.KcckApiBookingResponse response = submit(session, builder.build(), 10000L);
        BookingServiceProto.BookingExaminationResponse.Builder r = BookingServiceProto.BookingExaminationResponse.newBuilder();
        if (response != null) {
            if (!response.getResult()) {
                r.setResult(false);
                r.setErrCode(response.getErrCode());
                return r.build();
            }
            if (!StringUtils.isEmpty(response.getNewPatientCode())) {
                r.setNewPatientCode(response.getNewPatientCode());
            }
            if (!StringUtils.isEmpty(response.getDoctorCode())) {
                r.setDoctorCode(response.getDoctorCode());
            }
            r.setDoctorName(response.getDoctorName());
            r.setDepartmentName(response.getDepartmentName());
            r.setReservationCode(response.getReservationCode());
        }
        r.setResult(true);
        return r.build();
    }

    @Override
    public BookingServiceProto.BookingExaminationResponse bookingExamination(RpcApiSession session, BookingServiceProto.BookingExaminationRequest request) {
        final NuroServiceProto.KcckApiBookingRequest.Builder builder = NuroServiceProto.KcckApiBookingRequest.newBuilder()
                .setHospCode(request.getHospCode())
                .setDepartmentCode(request.getDepartmentCode())
                .setReservationDate(request.getReservationDate())
                .setReservationTime(request.getReservationTime())
                .setLocale(request.getLocale())
                .setDoctorCode(request.getDoctorCode())
                .setPatientCode(request.getPatientCode())
                .setPatientNameKanji(request.getPatientNameKanji())
                .setPatientNameKana(request.getPatientNameKana())
                .setPatientTel(request.getPatientTel())
                .setPatientEmail(request.getPatientEmail())
                .setPatientSex(request.getPatientSex())
                .setPatientBirthday(request.getPatientBirthday())
                .setPatientType(request.getPatientType())
                .setType(request.getType())
                .setUserId(request.getUserId())
                .setParentCode(request.getParentCode())
                .setChildCodeList(request.getChildCodeList())
                .setHangmogCode(request.getHangmogCode())
                .setHangmogName(request.getHangmogName())
                .setSurveyYn(request.getSurveyYn());

        final NuroServiceProto.KcckApiBookingResponse kcckResponse = submit(session, builder.build(), 60000L);
        BookingServiceProto.BookingExaminationResponse.Builder apiResponse = BookingServiceProto.BookingExaminationResponse.newBuilder();
        if (kcckResponse != null) {
            if (!kcckResponse.getResult()) {
            	apiResponse.setResult(false);
            	apiResponse.setErrCode(kcckResponse.getErrCode());
                return apiResponse.build();
            }
            
            apiResponse.setNewPatientCode(StringUtils.isEmpty(kcckResponse.getNewPatientCode()) ? "" : kcckResponse.getNewPatientCode());
            apiResponse.setDoctorCode(StringUtils.isEmpty(kcckResponse.getDoctorCode()) ? "" : kcckResponse.getDoctorCode());
            apiResponse.setDoctorName(kcckResponse.getDoctorName());
            apiResponse.setDepartmentName(kcckResponse.getDepartmentName());
            apiResponse.setReservationCode(kcckResponse.getReservationCode());
            apiResponse.setMisSurveyLink(kcckResponse.getMisSurveyLink() == null ? "" : kcckResponse.getMisSurveyLink());
            apiResponse.setResult(true);
            return apiResponse.build();
        }
        
        apiResponse.setResult(false);
        return apiResponse.build();
    }


    @Override
    public PatientServiceProto.SearchPatientResponse searchPatient(RpcApiSession session, PatientServiceProto.SearchPatientRequest request) {
        PatientServiceProto.SearchPatientResponse.Builder searchResponse = PatientServiceProto.SearchPatientResponse.newBuilder();

        final NuroServiceProto.PatientInfoRequest.Builder builder = NuroServiceProto.PatientInfoRequest.newBuilder();
        BeanUtils.copyProperties(request, builder, Language.JAPANESE.toString());
        final NuroServiceProto.PatientInfoResponse response = submit(session, builder.build(), 10000L);

        if (response != null) {
            List<NuroModelProto.PatientDetailInfo> listResponse = response.getPatientDetailInfoList();
            searchResponse.setPageIndex(request.getPageIndex());
            searchResponse.setPageSize(request.getPageSize());
            searchResponse.setTotalRecords(response.getTotalRecords());
            for (NuroModelProto.PatientDetailInfo info : listResponse) {
                PatientModelProto.PatientDetail.Builder item = PatientModelProto.PatientDetail.newBuilder();
                BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
                searchResponse.addPatientDetails(item);
            }
        }

        return searchResponse.build();
    }

	@Override
	public PatientServiceProto.SyncPatientResponse syncPatient(RpcApiSession session, PatientServiceProto.SyncPatientRequest request) {
		PatientServiceProto.SyncPatientResponse.Builder rp = PatientServiceProto.SyncPatientResponse.newBuilder();
		
		final NuroServiceProto.OUT0101U02SaveGridRequest.Builder builder = NuroServiceProto.OUT0101U02SaveGridRequest.newBuilder();
		builder.setUserId(request.getDoctorId());
		builder.setPatientCode("");
		builder.setAutoBunhoFlg("");
		builder.setOrcaRequest("true");
		builder.setOrcaGigwanCode(request.getHospCode());
		builder.setHospCode(request.getHospCode() != null ? request.getHospCode() : "");
		
		for (PatientModelProto.SyncPatient syncPatient : request.getPatientsList()) {
			NuroModelProto.NuroOUT0101U02GridPatientInfo.Builder patientBuilder = NuroModelProto.NuroOUT0101U02GridPatientInfo.newBuilder();
			BeanUtils.copyProperties(syncPatient, patientBuilder, Language.JAPANESE.toString());
			builder.addPatientList(patientBuilder.build());
		}
		
		List<PatientModelProto.PublicInsurance> publicInsList = request.getPublicInsurancesList();
		for (PatientModelProto.PublicInsurance ins : publicInsList) {
			NuroModelProto.NuroOUT0101U02GridBoheomInfo.Builder publicInsBuilder = NuroModelProto.NuroOUT0101U02GridBoheomInfo.newBuilder();
			BeanUtils.copyProperties(ins, publicInsBuilder, Language.JAPANESE.toString());
			builder.addBoheomList(publicInsBuilder.build());
		}
		
		List<PatientModelProto.PrivateInsurance> privateInsList = request.getPrivateInsurancesList();
		for (PatientModelProto.PrivateInsurance ins : privateInsList) {
			NuroModelProto.NuroOUT0101U02GridGongbiListInfo.Builder privateInsBuilder = NuroModelProto.NuroOUT0101U02GridGongbiListInfo.newBuilder();
			BeanUtils.copyProperties(ins, privateInsBuilder, Language.JAPANESE.toString());
			builder.addGongbiList(privateInsBuilder.build());
		}
		
		NuroServiceProto.OUT0101U02SaveGridRequest req = builder.build();
		final NuroServiceProto.OUT0101U02SaveGridResponse response = submit(session, req, 10000L);
		
		if(response != null && response.getResult()){
			rp.setResult(PatientServiceProto.SyncPatientResponse.Result.SUCCESS);
		} else {
			rp.setResult(PatientServiceProto.SyncPatientResponse.Result.INVALID);
		}
		
		return rp.build();
	}

	@Override
	public PatientServiceProto.SyncExaminationResponse syncExamination(RpcApiSession session, PatientServiceProto.SyncExaminationRequest request) {
		PatientServiceProto.SyncExaminationResponse.Builder rp = PatientServiceProto.SyncExaminationResponse.newBuilder();
		final NuroServiceProto.UpdateJubsuDataRequest.Builder builder = NuroServiceProto.UpdateJubsuDataRequest.newBuilder();
		builder.setIsOrca(true);
		builder.setOrcaGigwanCode(request.getHospCode());
		
		List<PatientModelProto.SyncExamination> examList = request.getExamInfoList();
		for (PatientModelProto.SyncExamination item : examList) {
			NuroModelProto.UpdateJubsuDataInfo.Builder info = NuroModelProto.UpdateJubsuDataInfo.newBuilder();
			BeanUtils.copyProperties(item, info, Language.JAPANESE.toString());
			
			PatientModelProto.ReceptionInfo reception = item.getReception();
			if(reception != null){
				NuroModelProto.OrcaReceptionInfo.Builder orcaReception = NuroModelProto.OrcaReceptionInfo.newBuilder();
				BeanUtils.copyProperties(reception, orcaReception, Language.JAPANESE.toString());
				info.setOrcaReceptionInfo(orcaReception);
			}
			
			builder.addDataInfo(info);
		}
		
		NuroServiceProto.UpdateJubsuDataRequest req = builder.build();
		final SystemServiceProto.UpdateResponse response = submit(session, req, 10000L);
		if(response != null && response.getResult()){
			rp.setResult(PatientServiceProto.SyncExaminationResponse.Result.SUCCESS);
		}else{
			rp.setResult(PatientServiceProto.SyncExaminationResponse.Result.INVALID);
		}
		
		return rp.build();
	}

	@Override
	public PatientServiceProto.SyncReservationResponse syncReservation(RpcApiSession session, PatientServiceProto.SyncReservationRequest request) {
		PatientServiceProto.SyncReservationResponse.Builder rp = PatientServiceProto.SyncReservationResponse.newBuilder();
		final NuroServiceProto.RES1001U00SaveLayoutItemRequest.Builder builder = NuroServiceProto.RES1001U00SaveLayoutItemRequest.newBuilder();
		if(request.getUserId() != null){
			builder.setUserId(request.getUserId());
		}
		
		List<PatientModelProto.SyncReservation> reserList = request.getReservationList();
		if(!CollectionUtils.isEmpty(reserList)){
			for (PatientModelProto.SyncReservation item : reserList) {
				NuroModelProto.RES1001U00SaveLayoutItemInfo.Builder info = NuroModelProto.RES1001U00SaveLayoutItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, Language.JAPANESE.toString());
				builder.addLayoutItem(info);
			}
		}
		
		if(request.getHospCodeLink() != null){
			builder.setHospCodeLink(request.getHospCodeLink());
		}
		
		builder.setTabIsAll(request.getTabIsAll());
		builder.setIsMssRequest(request.getIsMssRequest());
		builder.setIsExtAccounting(request.getIsExtAccounting());
		
		if(request.getHospCode() != null){
			builder.setHospCode(request.getHospCode());
		}
		
		final NuroServiceProto.RES1001U00SaveLayoutItemResponse response = submit(session, builder.build(), 10000L);
		if(response != null && response.getResult()){
			rp.setResult(PatientServiceProto.SyncReservationResponse.Result.SUCCESS);
		} else {
			rp.setResult(PatientServiceProto.SyncReservationResponse.Result.INVALID);
		}
		
		return rp.build();
	}
	
	@Override
	public ChangeBookingExaminationResponse changeBookingExamination(RpcApiSession session, ChangeBookingExaminationRequest request) {
		final NuroServiceProto.KcckApiChangeBookingRequest.Builder builder = NuroServiceProto.KcckApiChangeBookingRequest.newBuilder()
				.setHospCode(request.getHospCode())
				.setPatientCode(request.getPatientCode())
				.setReservationCode(request.getReservationCode())
				.setReservationDate(request.getReservationDate())
				.setReservationTime(request.getReservationTime())
				.setDoctorCode(request.getDoctorCode())
				.setDepartmentCode(request.getDepartmentCode())
		    	.setLocale(request.getLocale() == null ? "" : request.getLocale());

        final NuroServiceProto.KcckApiChangeBookingResponse kcckResponse = submit(session, builder.build(), 10000L);
        BookingServiceProto.ChangeBookingExaminationResponse.Builder apiResponse = BookingServiceProto.ChangeBookingExaminationResponse.newBuilder();
        if (kcckResponse != null) {
            if (!kcckResponse.getResult()) {
            	apiResponse.setResult(false);
            	apiResponse.setErrCode(kcckResponse.getErrCode());
                return apiResponse.build();
            }
            
            apiResponse.setDoctorCode(kcckResponse.getDoctorCode());
            apiResponse.setDoctorName(kcckResponse.getDoctorName());
            apiResponse.setDepartmentName(kcckResponse.getDepartmentName());
            apiResponse.setResult(true);
            return apiResponse.build();
        }
        apiResponse.setResult(false);
        return apiResponse.build();
	}

	@Override
	public CancelBookingExaminationResponse cancelBookingExamination(RpcApiSession session, CancelBookingExaminationRequest request) {
		final NuroServiceProto.KcckApiCancelBookingRequest.Builder builder = NuroServiceProto.KcckApiCancelBookingRequest.newBuilder()
				.setHospCode(request.getHospCode())
				.setPatientCode(request.getPatientCode())
				.setReservationCode(request.getReservationCode())
				.setLocale(request.getLocale());

        final NuroServiceProto.KcckApiCancelBookingResponse kcckResponse = submit(session, builder.build(), 10000L);
        BookingServiceProto.CancelBookingExaminationResponse.Builder apiResponse = BookingServiceProto.CancelBookingExaminationResponse.newBuilder();
        if (kcckResponse != null) {
            apiResponse.setResult(kcckResponse.getResult());
            return apiResponse.build();
        }
        apiResponse.setResult(false);
        return apiResponse.build();
	}

    @Override
    public HospitalServiceProto.SearchBookingScheduleResponse searchDoctorSchedule(RpcApiSession session, HospitalServiceProto.SearchBookingScheduleRequest request) {
        final NuroServiceProto.SearchBookingScheduleRequest.Builder builder = NuroServiceProto.SearchBookingScheduleRequest.newBuilder()
                .setHospCode(request.getHospCode())
                .setDepartment(request.getDepartment())
                .setStartDate(request.getStartDate())
                .setEndDate(request.getEndDate());

        final NuroServiceProto.SearchBookingScheduleResponse response = submit(session, builder.build(), 30000L);

        if(response != null) {
            HospitalServiceProto.SearchBookingScheduleResponse.Builder r = HospitalServiceProto.SearchBookingScheduleResponse.newBuilder();
            for (NuroModelProto.BookingSchedule schedule : response.getSchedulesList()) {
                HospitalModelProto.BookingSchedule.Builder item = HospitalModelProto.BookingSchedule.newBuilder();
                BeanUtils.copyProperties(schedule, item, Language.JAPANESE.toString());
                for (NuroModelProto.BookingScheduleDetail scheduleDetail : schedule.getPeriodList()) {
                	HospitalModelProto.BookingScheduleDetail.Builder itemDetail = HospitalModelProto.BookingScheduleDetail.newBuilder();
                    BeanUtils.copyProperties(scheduleDetail, itemDetail, Language.JAPANESE.toString());
                    item.addPeriod(itemDetail);
				}
                r.addSchedules(item);
            }
            r.setIsDifferentTimeFrame(response.getIsDifferentTimeFrame());
            r.setAvgTime(response.getAvgTime());
            return r.build();
        }

        throw new ServiceExecutionException();
    }

}
