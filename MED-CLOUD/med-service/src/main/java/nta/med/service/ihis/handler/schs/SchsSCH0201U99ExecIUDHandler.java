package nta.med.service.ihis.handler.schs;

import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.domain.ocs.Ocs1003;
import nta.med.core.domain.out.Out1001;
import nta.med.core.domain.sch.Sch0201;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99ExecIUDRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99ExecIUDResponse;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.TimeoutException;

@Service
@Scope("prototype")
@Transactional
public class SchsSCH0201U99ExecIUDHandler
		extends ScreenHandler<SchsServiceProto.SchsSCH0201U99ExecIUDRequest, SchsServiceProto.SchsSCH0201U99ExecIUDResponse> {

	@Resource
	private Sch0201Repository sch0201Repository;
	@Resource
	private Bas0102Repository bas0102Repository;
	@Resource
	private Out1001Repository out1001Repository;
	@Resource
	private Ocs1003Repository ocs1003Repository;
	@Resource
	private Ifs0003Repository ifs0003Repository;
	private static final Log LOGGER = LogFactory.getLog(Schs0201U99BookingLabHandler.class);
	private RpcMessageParser parser = new RpcMessageParser(NuroServiceProto.class);
	@Override
	@Transactional
	public SchsSCH0201U99ExecIUDResponse handle(Vertx vertx, String clientId,
												String sessionId, long contextId,
												SchsSCH0201U99ExecIUDRequest request) throws Exception {
		SchsServiceProto.SchsSCH0201U99ExecIUDResponse.Builder response = SchsServiceProto.SchsSCH0201U99ExecIUDResponse.newBuilder();
		String result = null;

		String sessionHospCode = getHospitalCode(vertx, sessionId);
		String errorCode = "0";
		if(!request.getIIudGubun().equals("D")){
			errorCode = validateNumberOder(sessionHospCode, request.getJundalTable(), request.getJundalPart(), request.getIReserDate());
		}
		try
		{
			for(SchsModelProto.SCH0201U99ListFkschInfo sch0201U99ListFkschInfo : request.getLstFkschList())
			{
				if(errorCode.equals("0"))
				{

					List<NuroServiceProto.BookingExaminationRequest.Builder> rollBackOrcaEvents = new ArrayList<>();
					LOGGER.info("SchsSCH0201U99ExecIUDHandler execute");
					LOGGER.info("getIIudGubun: "+ request.getIIudGubun());
					LOGGER.info("IKSch0201:"+  sch0201U99ListFkschInfo.getFkshc());
					Sch0201 schItem = sch0201Repository.findByHospCodeAndPksch0201(sessionHospCode, Double.valueOf(sch0201U99ListFkschInfo.getFkshc()));
					if(request.getIIudGubun().toUpperCase().equals("U") && !sessionHospCode.equals(request.getOutHospcode()))
					{
						//Sch0201 sch0201 = sch0201Repository.findByHospCodeAndPksch0201(sessionHospCode, Double.valueOf(sch0201U99ListFkschInfo.getFkshc()));
						//update OUT1001

						List<Ocs1003> ocs1003List = ocs1003Repository.findByHospCodeAndPk(sessionHospCode, schItem.getFkocs());
						if(!CollectionUtils.isEmpty(ocs1003List))
						{
							Out1001 out1001 = out1001Repository.findByHospCodeAndPkOut1001(sessionHospCode, ocs1003List.get(0).getFkout1001().doubleValue());
							out1001.setJubsuTime(request.getIReserTime());
							out1001.setNaewonDate(DateUtil.toDate(request.getIReserDate(), DateUtil.PATTERN_YYMMDD));
							out1001Repository.save(out1001);
						}


						//Change booking orca
						if(isUseOrcaCloud(sessionHospCode))
						{


							String dept = getDepartment(sessionHospCode, schItem);
							String doctor = getDoctor(sessionHospCode, schItem);


							//String doctor =  schItem.getDoctor().substring(2, schItem.getDoctor().length());
							NuroServiceProto.BookingExaminationResponse r = bookingOrca(vertx, sessionHospCode, DateUtil.toString(schItem.getReserDate(), DateUtil.PATTERN_YYMMDD),
									schItem.getReserTime(),schItem.getBunho(), dept, doctor,
									NuroServiceProto.BookingExaminationRequest.Action.CANCEL_BOOKING, rollBackOrcaEvents);
							NuroServiceProto.BookingExaminationResponse res = null;
							if(r != null && r.getResult())
							{
								res = bookingOrca(vertx, sessionHospCode, request.getIReserDate(),
										request.getIReserTime(), schItem.getBunho(), dept, doctor,
										NuroServiceProto.BookingExaminationRequest.Action.BOOKING, rollBackOrcaEvents);
							}

							else
							{
								rollbackOrcaEvent(vertx, sessionId, rollBackOrcaEvents);
							}
							if(res == null || !res.getResult())
							{
								response.setIoErr("1");
								return response.build();
							}

						}
					}

					result = sch0201Repository.callPrSchSch0210Iud(sessionHospCode, request.getIIudGubun(), sch0201U99ListFkschInfo.getFkshc(),
							DateUtil.toDate(request.getIReserDate(),DateUtil.PATTERN_YYMMDD), request.getIReserTime(), request.getIInputId(),"");


					if(request.getIIudGubun().toUpperCase().equals("D"))
					{
						cancelBooking(vertx, request, sessionHospCode, schItem, rollBackOrcaEvents);

					}

					if(!StringUtils.isEmpty(result)){

						response.setIoErr(result);
						if(!result.equals("0")) {
							break;
						}
					}
				}
				else {
					response.setIoErr("1");
					break;
				}
			}
			return response.build();
		}
		catch (Exception e)
		{
			throw new ExecutionException(response.build());
		}
	}
	private void rollbackOrcaEvent(Vertx vertx, String sessionId, List<NuroServiceProto.BookingExaminationRequest.Builder> rollBacks) throws InterruptedException, java.util.concurrent.ExecutionException, TimeoutException {
		for (NuroServiceProto.BookingExaminationRequest.Builder builder : rollBacks) {
			if (builder.getAction().equals(NuroServiceProto.BookingExaminationRequest.Action.BOOKING)) {
				builder.setAction(NuroServiceProto.BookingExaminationRequest.Action.CANCEL_BOOKING);
				LOGGER.info("SchsSCH0201U99ExecIUDRequest rollBack Action CANCEL_BOOKING");
				FutureEx<NuroServiceProto.BookingExaminationResponse> res = send(vertx, parser, builder.build(), getHospitalCode(vertx, sessionId));
				NuroServiceProto.BookingExaminationResponse r = res.get(30, TimeUnit.SECONDS);
				if (r == null || !r.getResult()) {
					LOGGER.info("SchsSCH0201U99ExecIUDRequest Fail to rollback CANCEL_BOOKING");
				}
			} else if (builder.getAction().equals(NuroServiceProto.BookingExaminationRequest.Action.CANCEL_BOOKING)) {
				builder.setAction(NuroServiceProto.BookingExaminationRequest.Action.BOOKING);
				LOGGER.info("SchsSCH0201U99ExecIUDRequest rollBack Action");
				FutureEx<NuroServiceProto.BookingExaminationResponse> res = send(vertx, parser, builder.build(), getHospitalCode(vertx, sessionId));
				NuroServiceProto.BookingExaminationResponse r = res.get(30, TimeUnit.SECONDS);
				if (r == null || !r.getResult()) {
					LOGGER.info("SchsSCH0201U99ExecIUDRequest Fail to rollback CANCEL_BOOKING");
				}
			}
		}
	}
	@Override
	public SchsSCH0201U99ExecIUDResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId, SchsSCH0201U99ExecIUDRequest request, SchsSCH0201U99ExecIUDResponse response) throws Exception {
		String sessionHospCode = getHospitalCode(vertx, sessionId);
		for(SchsModelProto.SCH0201U99ListFkschInfo sch0201U99ListFkschInfo : request.getLstFkschList())
		{
			if(request.getIIudGubun().toUpperCase().equals("U") && !sessionHospCode.equals(request.getOutHospcode()))
			{
				LOGGER.info("SchsSCH0201U99ExecIUDHandler Update");
				Sch0201 sch0201 = sch0201Repository.findByHospCodeAndPksch0201(sessionHospCode, Double.valueOf(sch0201U99ListFkschInfo.getFkshc()));
				//Update OutHospCode if the order that booking from other hospital
				List<Sch0201> sch0201s = sch0201Repository.findByFkOscAndHangCodeAndHospCode(sch0201.getFkocs(), sch0201.getHangmogCode(), sessionHospCode);
				LOGGER.info("SchsSCH0201U99ExecIUDHandler Update: " + sch0201s.size());
				for (Sch0201 item : sch0201s) {
					//if (item.getOutHospCode().equals(request.getOutHospcode())) {
					item.setOutHospCode(request.getOutHospcode());
					sch0201Repository.save(item);
					//}
				}
			}
		}
		return response;
	}

	private String getDoctor(String hospCode, Sch0201 schItem)
	{
		List<Ifs0003> doctorLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode, AccountingConfig.IF_ORCA_DOCTOR.getValue(), schItem.getDoctor().substring(2, schItem.getDoctor().length()));
		String doctor = !org.springframework.util.CollectionUtils.isEmpty(doctorLst) ? doctorLst.get(0).getIfCode() : "";
		LOGGER.info("SchsSCH0201U99ExecIUDRequest doctor: " + doctor);
		return doctor;

	}
	private String getDepartment(String hospCode, Sch0201 schItem)
	{
		List<Ifs0003> gwaLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode, AccountingConfig.IF_ORCA_GWA.getValue(), schItem.getGwa());
		String dept = !org.springframework.util.CollectionUtils.isEmpty(gwaLst) ? gwaLst.get(0).getIfCode() : "";
		LOGGER.info("SchsSCH0201U99ExecIUDRequest dept: "+ dept);
		return dept;
	}
	private boolean cancelBooking(Vertx vertx, SchsSCH0201U99ExecIUDRequest request, String sessionHospCode, Sch0201 schItem,
								  List<NuroServiceProto.BookingExaminationRequest.Builder>  rollBackOrcaEvents)
			throws  ExecutionException, TimeoutException {


		if(schItem != null && schItem.getFkOcs1003c() != null)
        {


            //cancel order from tab other clinic
            Sch0201 sch0201 = sch0201Repository.findByOutHospCodeAndPksch0201(sessionHospCode, schItem.getPksch0201Out());

            if(sch0201 != null && sch0201.getFkocs() != null)
            {

                Sch0201 sch0101ByFkOcs =  sch0201Repository.getPkSCH0101ByFkOcs(sch0201.getFkocs(), sch0201.getHangmogCode(), sch0201.getHospCode());
                if(sch0101ByFkOcs != null)
                {


                    sch0201Repository.callPrSchSch0210Iud(sch0101ByFkOcs.getHospCode(), request.getIIudGubun(), sch0101ByFkOcs.getPksch0201().toString(),
							DateUtil.toDate(request.getIReserDate(), DateUtil.PATTERN_YYMMDD), request.getIReserTime(), request.getIInputId(), "");

					deleteOrder(sch0101ByFkOcs);
                }

				if(sch0101ByFkOcs != null && isUseOrcaCloud(sch0101ByFkOcs.getHospCode()))
				{

					String dept = getDepartment(sch0101ByFkOcs.getHospCode(), sch0101ByFkOcs);
					String doctor = getDoctor(sch0101ByFkOcs.getHospCode(), sch0101ByFkOcs);

					//cancel booking orca
					NuroServiceProto.BookingExaminationResponse r = bookingOrca(vertx, sch0101ByFkOcs.getHospCode(), DateUtil.toString(sch0101ByFkOcs.getReserDate(), DateUtil.PATTERN_YYMMDD),
							sch0101ByFkOcs.getReserTime(), sch0101ByFkOcs.getBunho(),dept, doctor, NuroServiceProto.BookingExaminationRequest.Action.CANCEL_BOOKING, rollBackOrcaEvents);

					if (r == null || !r.getResult()) {
						String errCode = "";
						if (r.hasErrCode()) {
							if(r.getErrCode().equals("25"))
							{
								LOGGER.warn("Cancel Booking Orca: It does not exist delete the reservation record");
								return true;
							}
							LOGGER.info("Fail to Cancel Booking Orca, Error Code = " + errCode);
						} else {
							LOGGER.info("Fail to Cancel Booking Orca, Error Code");
						}
						throw new ExecutionException(r.toBuilder().build());


					}
				}
            }

        } else if (!sessionHospCode.equals(request.getOutHospcode()) && schItem.getFkocs() != null) {

			//cancel order from In Myclinic
			deleteOrder(schItem);
			if(isUseOrcaCloud(schItem.getHospCode()))
			{


				String dept = getDepartment(sessionHospCode, schItem);
				String doctor = getDoctor(sessionHospCode, schItem);


				//cancel booking orca
				NuroServiceProto.BookingExaminationResponse r = bookingOrca(vertx, schItem.getHospCode(), DateUtil.toString(schItem.getReserDate(), DateUtil.PATTERN_YYMMDD),
						schItem.getReserTime(), schItem.getBunho(), dept, doctor,
						NuroServiceProto.BookingExaminationRequest.Action.CANCEL_BOOKING, rollBackOrcaEvents);

				if (r == null || !r.getResult()) {
					String errCode = "";
					if (r.hasErrCode()) {
						if (r.getErrCode().equals("25")) {
							LOGGER.warn("Cancel Booking Orca: It does not exist delete the reservation record");

						} else {
							LOGGER.info("Fail to Cancel Booking Orca, Error Code = " + errCode);
							throw new ExecutionException(r.toBuilder().build());
						}

					} else {
						LOGGER.info("Fail to Cancel Booking Orca, Error Code");
						throw new ExecutionException(r.toBuilder().build());
					}

				}
			}

			List<Sch0201> sch0201s = sch0201Repository.findByFkOscAndHangCodeAndHospCode(schItem.getFkocs(), schItem.getHangmogCode(), schItem.getHospCode());
			for (Sch0201 sch : sch0201s) {
				Sch0201 sch0201 = sch0201Repository.findByHospCodeAndPksch0201Out(sch.getOutHospCode(), sch.getPksch0201());
				if (sch0201 != null) {
					sch0201Repository.callPrSchSch0210Iud(sch0201.getHospCode(), request.getIIudGubun(), sch0201.getPksch0201().toString(),
							DateUtil.toDate(request.getIReserDate(), DateUtil.PATTERN_YYMMDD), request.getIReserTime(), request.getIInputId(), "");
					break;
				}

			}


		}
		return true;
	}

	private void deleteOrder(Sch0201 sch0201) {
		List<Ocs1003> ocs1003List = ocs1003Repository.findByHospCodeAndPk(sch0201.getHospCode(), sch0201.getFkocs());
		if(!CollectionUtils.isEmpty(ocs1003List))
        {
            Ocs1003 ocs1003 = ocs1003List.get(0);
            ocs1003.setDcYn("Y");
            ocs1003Repository.save(ocs1003);

			Out1001 out1001 = out1001Repository.findByHospCodeAndPkOut1001(sch0201.getHospCode(), ocs1003List.get(0).getFkout1001().doubleValue());
			if(out1001 != null)
			{
				out1001Repository.delete(out1001);
			}

        }

	}



	private boolean isUseOrcaCloud(String hospCode)
	{
		List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(hospCode, AccountingConfig.ACCT_TYPE.getValue());
		return !org.springframework.util.CollectionUtils.isEmpty(bas0102List) && AccountingConfig.ACCCT_TYPE_ORCA.getValue().
				equalsIgnoreCase(bas0102List.get(0).getCode())  ;
	}
	private NuroServiceProto.BookingExaminationResponse bookingOrca(Vertx vertx, String hospCode, String reserDate, String reserTime,
																	String patientCode, String dept, String doctor, NuroServiceProto.BookingExaminationRequest.Action action,
																	List<NuroServiceProto.BookingExaminationRequest.Builder> rollBacks)
	{
		NuroServiceProto.BookingExaminationResponse r = null;
		try
		{
			NuroServiceProto.BookingExaminationRequest.Builder builder = NuroServiceProto.BookingExaminationRequest
					.newBuilder()
					.setHospCode(hospCode)
					.setDepartmentCode(dept)
					.setDoctorCode(doctor)
					.setReservationDate(reserDate)
					.setReservationTime(reserTime)
					.setPatientCode(patientCode)
					.setPatientTel("")
					.setPatientSex("")
					.setPatientBirthday("")
					.setLocale("")
					.setPatientType("")
					.setType("")
					.setUserId("")
					.setReservationCode("")
					.setAction(action);
			LOGGER.info("Request cancel booking patient_code = " + patientCode);
			FutureEx<NuroServiceProto.BookingExaminationResponse> res = send(vertx, parser, builder.build(), hospCode);
			r = res.get(30, TimeUnit.SECONDS);
			if(r != null && r.getResult())
			{
				rollBacks.add(builder);
			}
		}
		catch (Exception e) {
			LOGGER.info("Booking to orca error");
			throw new ExecutionException(r);
		}

		return r;
	}
	private String validateNumberOder(String hospCode, String jundalTable, String jundalPart, String reserDate) {

		String inWon = sch0201Repository.getSchTotalInWon(hospCode, jundalTable, jundalPart, reserDate);
		String outWon = sch0201Repository.getSchTotalOutWon(hospCode, jundalTable, jundalPart, reserDate);
		Integer totalBookingIn = CommonUtils.parseInteger(inWon.split("/")[0]);
		Integer maxLabSlot = CommonUtils.parseInteger(inWon.split("/")[1]);
		Integer totalBookingOut = CommonUtils.parseInteger(outWon.split("/")[0]);
		Integer maxLabOut = CommonUtils.parseInteger(outWon.split("/")[1]);
		if(
//				totalBookingIn >= maxLabSlot
//				|| totalBookingOut >= maxLabOut
//				|| 
				(totalBookingIn + totalBookingOut) >= maxLabSlot){
			return "1";
		}
		return "0";
	}
}
