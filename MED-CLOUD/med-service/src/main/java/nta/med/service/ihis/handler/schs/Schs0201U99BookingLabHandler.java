package nta.med.service.ihis.handler.schs;

import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.domain.ocs.Ocs1003;
import nta.med.core.domain.ocs.Ocs1003C;
import nta.med.core.domain.out.Out1001;
import nta.med.core.domain.sch.Sch0201;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.ocs.Ocs1003cRepository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.nuro.BookingLabInfo;
import nta.med.data.model.ihis.schs.ResultAndMessageCode;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.logging.log4j.util.Strings;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.TimeoutException;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
@Transactional
public class Schs0201U99BookingLabHandler extends ScreenHandler<SchsServiceProto.Schs0201U99BookingLabRequest, SchsServiceProto.Schs0201U99BookingLabResponse> {
    @Resource
    Out1001Repository out1001Repository;
    @Resource
    Ocs1003Repository ocs1003Repository;

    @Resource
    Ocs1003cRepository ocs1003CRepository;

    @Resource
    Sch0201Repository sch0201Repository;
    @Resource
    CommonRepository commonRepository;
    @Resource
    Ifs0003Repository ifs0003Repository;
    @Resource
    Bas0102Repository bas0102Repository;
    private RpcMessageParser parser = new RpcMessageParser(NuroServiceProto.class);
    private static final Log LOGGER = LogFactory.getLog(Schs0201U99BookingLabHandler.class);

    @Override
    public SchsServiceProto.Schs0201U99BookingLabResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, SchsServiceProto.Schs0201U99BookingLabRequest request) throws Exception {
        boolean useOrcaCloud = false;
        SchsServiceProto.Schs0201U99BookingLabResponse.Builder response = SchsServiceProto.Schs0201U99BookingLabResponse.newBuilder();
        response.setErrCode("0");
        Boolean isProcessOrca = true;
        ResultAndMessageCode result = new ResultAndMessageCode();
        List<NuroServiceProto.BookingExaminationRequest.Builder> rollBackOrcaEvents = new ArrayList<>();
        String dept = null;
        String doctor = null;
        try {


            List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(request.getHospCode(), AccountingConfig.ACCT_TYPE.getValue());
            useOrcaCloud = !org.springframework.util.CollectionUtils.isEmpty(bas0102List) && AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(bas0102List.get(0).getCode());


            for (SchsModelProto.SCH0201U99ListFkschInfo sch0201U99ListFkschInfo : request.getLstFkschList()) {
                LOGGER.info("Schs0201U99BookingLabHandler hosp_code" + request.getHospCode());
                LOGGER.info("Schs0201U99BookingLabHandler out_hosp_code" + request.getOutHospcode());
                LOGGER.info("Schs0201U99BookingLabHandler fkschc" + sch0201U99ListFkschInfo.getFkshc());

                //Booking orca
                List<Ifs0003> gwaLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(request.getHospCode(), AccountingConfig.IF_ORCA_GWA.getValue(), request.getGwa());
                List<Ifs0003> doctorLst = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(request.getHospCode(), AccountingConfig.IF_ORCA_DOCTOR.getValue(), request.getDoctor().substring(2, request.getDoctor().length()));
                dept = !org.springframework.util.CollectionUtils.isEmpty(gwaLst) ? gwaLst.get(0).getIfCode() : "";
                doctor = !org.springframework.util.CollectionUtils.isEmpty(doctorLst) ? doctorLst.get(0).getIfCode() : "";

                Sch0201 sch0201InMyClinic = sch0201Repository.findByHospCodeAndPksch0201(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(sch0201U99ListFkschInfo.getFkshc()));
                if(useOrcaCloud)
                {
                	 LOGGER.info("Schs0201U99BookingLabHandler useOrcaCloud : " + useOrcaCloud);
//                    isProcessOrca = callToOrcaSystem(vertx, sessionId, request, isProcessOrca, rollBackOrcaEvents, dept, doctor, sch0201InMyClinic);
                	result = callToOrcaSystem(vertx, sessionId, request, rollBackOrcaEvents, dept, doctor, sch0201InMyClinic);
                	isProcessOrca = result.getResult();

                }
                LOGGER.info("Schs0201U99BookingLabHandler isProcessOrca : " + isProcessOrca);
                if(isProcessOrca)
                {

                     callBookingAuto(getHospitalCode(vertx, sessionId), request, response, sch0201U99ListFkschInfo, sch0201InMyClinic);

                }
                else
                {
                    //rollback transaction orca
                    //response.setErrCode("1");
                	response.setErrCode(StringUtils.isEmpty(result.getMsg()) ? "" : result.getMsg());
                }

            }
        } catch (Exception e) {
        	LOGGER.error("exception Schs0201U99BookingLabHandler ", e);
        	
//            LOGGER.error("exception Schs0201U99BookingLabHandler :" + e);
//            if (e.getCause() != null) {
//                LOGGER.error("exception Schs0201U99BookingLabHandler :" + e.getCause().getMessage());
//            }
            
            //cancel booking on orca
            LOGGER.error("exception Schs0201U99BookingLabHandler isProcessOrca :" + isProcessOrca);
            if(useOrcaCloud && isProcessOrca && !StringUtils.isEmpty(dept) && !StringUtils.isEmpty(doctor))
            {
                rollbackOrcaEvent(vertx, sessionId, rollBackOrcaEvents);
            }
            response.setErrCode("1");
            throw new ExecutionException(response.build());
        }

        return response.build();
    }

    private void callBookingAuto(String hospCode, SchsServiceProto.Schs0201U99BookingLabRequest request, SchsServiceProto.Schs0201U99BookingLabResponse.Builder response, SchsModelProto.SCH0201U99ListFkschInfo sch0201U99ListFkschInfo, Sch0201 sch0201InMyClinic) {
        if (sch0201InMyClinic != null && sch0201InMyClinic.getPksch0201Out() != null) {
            updateBookingLab(hospCode, request, sch0201InMyClinic);
        } else {
            createNewBookingLab(hospCode, request, response, sch0201U99ListFkschInfo);
        }

    }

    private boolean createNewBookingLab(String hospCode, SchsServiceProto.Schs0201U99BookingLabRequest request, SchsServiceProto.Schs0201U99BookingLabResponse.Builder response,
                                        SchsModelProto.SCH0201U99ListFkschInfo sch0201U99ListFkschInfo) {
        List<BookingLabInfo> bookingLabInfos = out1001Repository.getBookingLabInfo(request.getDoctor(), request.getGwa(),
                request.getBunhoLink(), request.getHospCode(), request.getReserDate(), request.getReserTime());

        List<Ocs1003C> ocs1003CList = ocs1003CRepository.getByHospCodeAndFks0201(hospCode, Double.parseDouble(sch0201U99ListFkschInfo.getFkshc()));
        List<Double> listTJubsuNo = out1001Repository.getNuroRES1001U00ReceptionNumber(request.getHospCode(), hospCode,
                request.getBunhoLink(), request.getReserDate(), true);
        if (CollectionUtils.isEmpty(listTJubsuNo)) {
            LOGGER.info("Schs0201U99BookingLabHandler: hasn't any record of ocs1003C");
            response.setErrCode("1");
            return true;
        }
        String gunbun = "";
        if (!CollectionUtils.isEmpty(ocs1003CList) && ocs1003CList.get(0).getFkout1001() != null) {
            gunbun = out1001Repository.getGubun(ocs1003CList.get(0).getFkout1001().toString(), request.getOutHospcode());
        }
        if (CollectionUtils.isEmpty(bookingLabInfos)) {
            if (!reservationBookingLabThatHasNotAnyAppointment(hospCode, request, response, sch0201U99ListFkschInfo, ocs1003CList, listTJubsuNo, gunbun)) {
                response.setErrCode("1");
                return true;
            }

        } else {
            //check have out1001 that exist
            if (!reservationBookingLapThatHasAppointment(hospCode, request, response, sch0201U99ListFkschInfo, bookingLabInfos, ocs1003CList, gunbun)) {
                response.setErrCode("1");
                return true;
            }

        }
        return false;
    }

    private ResultAndMessageCode callToOrcaSystem(Vertx vertx, String sessionId, SchsServiceProto.Schs0201U99BookingLabRequest request, List<NuroServiceProto.BookingExaminationRequest.Builder> rollBackOrcaEvents,
                                     String dept, String doctor, Sch0201 sch0201InMyClinic) throws InterruptedException, java.util.concurrent.ExecutionException, TimeoutException {
    	ResultAndMessageCode result = new ResultAndMessageCode();
    	if(sch0201InMyClinic == null || sch0201InMyClinic.getPksch0201Out() == null)
        {
            List<BookingLabInfo> bookingLabInfos = out1001Repository.getBookingLabInfo(request.getDoctor(), request.getGwa(),
                    request.getBunhoLink(), request.getHospCode(), request.getReserDate(), request.getReserTime());

            //booking new
            try
            {
                if (CollectionUtils.isEmpty(bookingLabInfos)) {


                    NuroServiceProto.BookingExaminationResponse bookingExaminationResponse = bookingOrca(vertx, request.getHospCode(),
                            getHospitalCode(vertx, sessionId), request.getReserDate(),
                            request.getReserTime(), request.getBunhoLink(), request.getNameKanji(), request.getNameKana(), dept,
                            doctor, NuroServiceProto.BookingExaminationRequest.Action.BOOKING, rollBackOrcaEvents);

//                    isProcessOrca = bookingExaminationResponse.getResult();
                    result.setResult(bookingExaminationResponse.getResult());
                    result.setMsg(bookingExaminationResponse.getErrCode());
                }
            }
            catch (Exception e)
            {
//                isProcessOrca = false;
            	LOGGER.error(" Exception Schs0201U99BookingLabHandler callToOrcaSystem : " + e);
            	result.setResult(false);
            }

        }
        else
        {

            Sch0201 sch0201FKocs = sch0201Repository.findByHospCodeAndPksch0201(request.getHospCode(), sch0201InMyClinic.getPksch0201Out());
            if (sch0201FKocs != null) {
                LOGGER.info("Schs0201U99BookingLabHandler sch0201FKocs" + sch0201FKocs.getFkocs());
                //get lasest reserved
                Sch0201 sch0201 = sch0201Repository.getPkSCH0101ByFkOcs(sch0201FKocs.getFkocs(), sch0201FKocs.getHangmogCode(), request.getHospCode());

                String isExistBookingDate = sch0201Repository.
                        isExistBookingDate(request.getReserDate(), sch0201FKocs.getFkocs(), sch0201FKocs.getHangmogCode(), request.getHospCode());
                //update booking
//                isProcessOrca = updateBookingToOrca(vertx, sessionId, request, dept,
//                        doctor, doctor, DateUtil.toString(sch0201.getReserDate(), DateUtil.PATTERN_YYMMDD), sch0201.getReserTime(), isExistBookingDate, rollBackOrcaEvents);
                result = updateBookingToOrca(vertx, sessionId, request, dept,
                        doctor, doctor, DateUtil.toString(sch0201.getReserDate(), DateUtil.PATTERN_YYMMDD), sch0201.getReserTime(), isExistBookingDate, rollBackOrcaEvents);

            }


        }
//        return isProcessOrca;
        return result;
    }

    private ResultAndMessageCode updateBookingToOrca(Vertx vertx, String sessionId, SchsServiceProto.Schs0201U99BookingLabRequest request,
                                        String dept, String oldDoctor, String newDoctor, String oldReservationDate, String oldReservationTime,
                                        String isExistBookingDate, List<NuroServiceProto.BookingExaminationRequest.Builder> rollBacks)
            throws InterruptedException, java.util.concurrent.ExecutionException, TimeoutException {
        boolean isSuccess = true;
        String errCode = "0";
        try {
            if (isExistBookingDate.equals("Y")) {

                NuroServiceProto.BookingExaminationResponse r = bookingOrca(vertx, request.getHospCode(), getHospitalCode(vertx, sessionId), oldReservationDate,
                        oldReservationTime, request.getBunhoLink(), request.getNameKanji(), request.getNameKana(), dept, oldDoctor, NuroServiceProto.BookingExaminationRequest.Action.CANCEL_BOOKING, rollBacks);
                // cancel booking in external system
                if (r == null || !r.getResult()) {
                    isSuccess = false;
                    errCode = r.getErrCode();
                    if (r.hasErrCode()) {
                        LOGGER.info("Fail to Cancel Booking Examination to External System (Case cancel booking 1), Error Code = " + errCode);
                    } else {
                        LOGGER.info("Fail to Cancel Booking Examination to External System (Case cancel booking 1) !");
                    }


                }
            }
           if (isSuccess) {
                // booking-new in external system
                NuroServiceProto.BookingExaminationResponse rNew = bookingOrca(vertx, request.getHospCode(), getHospitalCode(vertx, sessionId), request.getReserDate(),
                        request.getReserTime(), request.getBunhoLink(), request.getNameKanji(), request.getNameKana(), dept,
                        newDoctor, NuroServiceProto.BookingExaminationRequest.Action.BOOKING, rollBacks);
                if (rNew == null || !rNew.getResult()) {
                    isSuccess = false;
                    errCode = rNew.getErrCode();
                    if (rNew.hasErrCode()) {
                        LOGGER.info("Fail to Booking Examination to External System (Case Booking 2), Error Code = " + errCode);
                    } else {
                        LOGGER.info("Fail to Booking Examination to External System (Case Booking 2) !");
                    }


                }
                else
                {
                    isSuccess = true;
                }
            }
            if (!isSuccess) {
                //LOGGER.info("Fail to Booking Examination to External System (Case Booking 2) !");
            	LOGGER.info(" Exception Schs0201U99BookingLabHandler updateBookingToOrca isSuccess : " + isSuccess);
                rollbackOrcaEvent(vertx, sessionId, rollBacks);
            }


        } catch (Exception e) {
        	LOGGER.error(" Exception Schs0201U99BookingLabHandler updateBookingToOrca : " + e);
            isSuccess = false;
            errCode = "";
            rollbackOrcaEvent(vertx, sessionId, rollBacks);
        }


//        return isSuccess;
        return new ResultAndMessageCode(isSuccess, errCode);
    }

    private void rollbackOrcaEvent(Vertx vertx, String sessionId, List<NuroServiceProto.BookingExaminationRequest.Builder> rollBacks) throws InterruptedException, java.util.concurrent.ExecutionException, TimeoutException {
        for (NuroServiceProto.BookingExaminationRequest.Builder builder : rollBacks) {
            if (builder.getAction().equals(NuroServiceProto.BookingExaminationRequest.Action.BOOKING)) {
                builder.setAction(NuroServiceProto.BookingExaminationRequest.Action.CANCEL_BOOKING);
                LOGGER.info("Schs0201U99BookingLabHandler rollBack Action CANCEL_BOOKING");
                FutureEx<NuroServiceProto.BookingExaminationResponse> res = send(vertx, parser, builder.build(), getHospitalCode(vertx, sessionId));
                NuroServiceProto.BookingExaminationResponse r = res.get(30, TimeUnit.SECONDS);
                if (r == null || !r.getResult()) {
                    LOGGER.info("Fail to rollback CANCEL_BOOKING");
                }
            } else if (builder.getAction().equals(NuroServiceProto.BookingExaminationRequest.Action.CANCEL_BOOKING)) {
                builder.setAction(NuroServiceProto.BookingExaminationRequest.Action.BOOKING);
                LOGGER.info("Schs0201U99BookingLabHandler rollBack Action");
                FutureEx<NuroServiceProto.BookingExaminationResponse> res = send(vertx, parser, builder.build(), getHospitalCode(vertx, sessionId));
                NuroServiceProto.BookingExaminationResponse r = res.get(30, TimeUnit.SECONDS);
                if (r == null || !r.getResult()) {
                    LOGGER.info("Fail to rollback CANCEL_BOOKING");
                }
            }
        }
    }

    private NuroServiceProto.BookingExaminationResponse bookingOrca(Vertx vertx, String hospCode, String sessionHospCode, String reserDate, String reserTime, String patientCode, String nameKaji, String namkana,
                                                                           String dept, String doctor,
                                NuroServiceProto.BookingExaminationRequest.Action action,  List<NuroServiceProto.BookingExaminationRequest.Builder> rollBacks) throws InterruptedException, java.util.concurrent.ExecutionException, TimeoutException {
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
                    .setPatientNameKanji(nameKaji)
                    .setPatientNameKana(namkana)
                    .setPatientTel("")
                    .setPatientSex("")
                    .setPatientBirthday("")
                    .setLocale("")
                    .setPatientType("")
                    .setType("")
                    .setUserId("")
                    .setReservationCode("")
                    .setAction(action);



            LOGGER.info("Request Booking Examination to external system: patient_code = " + patientCode);
            FutureEx<NuroServiceProto.BookingExaminationResponse> res = send(vertx, parser, builder.build(), sessionHospCode);
            r = res.get(30, TimeUnit.SECONDS);
            if(r != null && r.getResult())
            {
                rollBacks.add(builder);
            }
        }
        catch (Exception e) {
            LOGGER.info("Booking to orca error", e);
        }

        return r;
    }

    private boolean reservationBookingLapThatHasAppointment(String hospCode, SchsServiceProto.Schs0201U99BookingLabRequest request, SchsServiceProto.Schs0201U99BookingLabResponse.Builder response, SchsModelProto.SCH0201U99ListFkschInfo sch0201U99ListFkschInfo, List<BookingLabInfo> bookingLabInfos, List<Ocs1003C> ocs1003CList, String gunbun) {
        Out1001 out1001 = out1001Repository.findOne(bookingLabInfos.get(0).getId().longValue());
        if (Strings.isEmpty(out1001.getGubun()) ||
                (StringUtils.isEmpty(out1001.getNaewonYn())) ||
                (out1001.getNaewonYn() != null && !out1001.getNaewonYn().equals("Y"))) {
            out1001.setGubun(gunbun);
            out1001.setSysId("99999");
            out1001.setNaewonYn("Y");
            out1001.setJubsuTime(request.getReserTime());
            out1001Repository.save(out1001);
        }

        LOGGER.info("Schs0201U99BookingLabHandler: create ocs1003");
        //save booking order
        if (!CollectionUtils.isEmpty(ocs1003CList)) {
            Ocs1003 ocs1003 = saveOcs1003(request, ocs1003CList.get(0),
                    request.getBunhoLink(), request.getDoctor(), request.getGwa(), new BigDecimal(bookingLabInfos.get(0).getFkOut1001()));
            Double fksCh0201 = sch0201Repository.getPkSCH0101ByFkOcs(ocs1003.getPkocs1003().toString(), ocs1003.getHangmogCode());
            //save booking lab
            if (!reserverBookingLab(hospCode, request, sch0201U99ListFkschInfo, fksCh0201)) {
                response.setErrCode("1");
                return false;
            }
        }
        return true;
    }

    private boolean reservationBookingLabThatHasNotAnyAppointment(String hospCode, SchsServiceProto.Schs0201U99BookingLabRequest request,
                                                                  SchsServiceProto.Schs0201U99BookingLabResponse.Builder response,
                                                                  SchsModelProto.SCH0201U99ListFkschInfo sch0201U99ListFkschInfo,
                                                                  List<Ocs1003C> ocs1003List, List<Double> listTJubsuNo, String gunbun) {
        LOGGER.info("Schs0201U99BookingLabHandler: create out1001");
        String result = out1001Repository.getNuroOUT1001U01GetOut1001Seq("OUT1001_SEQ");

        Out1001 out1001 = createOut1001(request, listTJubsuNo, gunbun, result);
        //save booking order
        if (!CollectionUtils.isEmpty(ocs1003List)) {
            LOGGER.info("Schs0201U99BookingLabHandler: create ocs1003 from out1001");
            Ocs1003 ocs1003 = saveOcs1003(request, ocs1003List.get(0),
                    request.getBunhoLink(), out1001.getDoctor(), out1001.getGwa(), new BigDecimal(out1001.getPkout1001()));

            Double fksCh0201 = sch0201Repository.getPkSCH0101ByFkOcs(ocs1003.getPkocs1003().toString(), ocs1003.getHangmogCode());
            //save booking lab
            if (!reserverBookingLab(hospCode, request, sch0201U99ListFkschInfo, fksCh0201)) {
                response.setErrCode("1");
                return false;
            }
        }
        return true;
    }

    private void updateBookingLab(String hospCode, SchsServiceProto.Schs0201U99BookingLabRequest request, Sch0201 sch0201InMyClinic) {

        LOGGER.info("Schs0201U99BookingLabHandler sch0201InMyClinic" + sch0201InMyClinic.getPksch0201Out());
        Sch0201 sch0201FKocs = sch0201Repository.findByHospCodeAndPksch0201(request.getHospCode(), sch0201InMyClinic.getPksch0201Out());
        Sch0201 sch0201 = sch0201Repository.getPkSCH0101ByFkOcs(sch0201FKocs.getFkocs(), sch0201FKocs.getHangmogCode(), request.getHospCode());
        List<Ocs1003> ocs1003List = ocs1003Repository.findByHospCodeAndPk(request.getHospCode(), sch0201.getFkocs());
        if(!CollectionUtils.isEmpty(ocs1003List))
        {
            Out1001 out1001 = out1001Repository.findByHospCodeAndPkOut1001(request.getHospCode(), ocs1003List.get(0).getFkout1001().doubleValue());
            out1001.setJubsuTime(request.getReserTime());
            out1001.setNaewonDate(DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD));
            out1001Repository.save(out1001);
        }

        sch0201Repository.callPrSchSch0210IudOther(request.getHospCode(), hospCode, request.getIudGubun(), sch0201InMyClinic.getPksch0201Out().toString(),
                DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD), request.getReserTime(), request.getInputId(), "");


        if (sch0201FKocs != null) {
            LOGGER.info("Schs0201U99BookingLabHandler sch0201FKocs" + sch0201FKocs.getFkocs());
            //get lasest reserved
            sch0201 = sch0201Repository.getPkSCH0101ByFkOcs(sch0201FKocs.getFkocs(), sch0201FKocs.getHangmogCode(), request.getHospCode());
            if (sch0201 != null) {


                LOGGER.info("Schs0201U99BookingLabHandler sch0201" + sch0201.getPksch0201());
                LOGGER.info("Schs0201U99BookingLabHandler sch0201" + sch0201.getOutHospCode());
                sch0201.setOutHospCode(hospCode);
                sch0201Repository.save(sch0201);



            }
        }
    }

    private boolean reserverBookingLab(String hospCode,
                                       SchsServiceProto.Schs0201U99BookingLabRequest request, SchsModelProto.SCH0201U99ListFkschInfo sch0201U99ListFkschInfo,
                                       Double fksch0201) {
        LOGGER.info("Schs0201U99BookingLabHandler: callPrSchSch0210IudOther");
        String resultBooking = sch0201Repository.callPrSchSch0210IudOther(request.getHospCode(), hospCode,
                request.getIudGubun(), fksch0201.toString(),
                DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD), request.getReserTime(), request.getInputId(), "");
        if (!resultBooking.equals("0")) {
            return false;
        }
        Sch0201 sch0201 = sch0201Repository.findByHospCodeAndPksch0201(hospCode, CommonUtils.parseDouble(sch0201U99ListFkschInfo.getFkshc()));
        sch0201.setPksch0201Out(fksch0201);
        sch0201Repository.save(sch0201);
        return true;
    }

    private Ocs1003 saveOcs1003(SchsServiceProto.Schs0201U99BookingLabRequest request,
                                Ocs1003C ocs1003Item, String bunho, String doctor, String gwa, BigDecimal fkOut1001) {
        Ocs1003 ocs1003 = new Ocs1003();
        BeanUtils.copyProperties(ocs1003Item, ocs1003, "JA");
        ocs1003.setId(null);
        ocs1003.setSysId("99999");
        ocs1003.setBunho(bunho);
        ocs1003.setHospCode(request.getHospCode());
        ocs1003.setDoctor(doctor);
        ocs1003.setGwa(gwa);
        ocs1003.setFkout1001(fkOut1001);
        ocs1003.setPkocs1003(Double.parseDouble(commonRepository.getNextVal("OCSKEY_SEQ")));
        ocs1003.setReserDate(DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD));
        ocs1003.setHopeDate(DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD));
        ocs1003Repository.save(ocs1003);
        return ocs1003;
    }

    private Out1001 createOut1001(SchsServiceProto.Schs0201U99BookingLabRequest request, List<Double> listTJubsuNo, String gunbun, String result) {
        Out1001 out1001 = new Out1001();
        out1001.setUpdDate(new Date());
        out1001.setPkout1001(CommonUtils.parseDouble(result));
        out1001.setResChanggu(request.getChangu());
        out1001.setJubsuTime(request.getReserTime());
        out1001.setChojae(request.getChojae());
        out1001.setDoctor(request.getDoctor());
        out1001.setGubun(gunbun);
        out1001.setGwa(request.getGwa());
        out1001.setResInputGubun(request.getInputGubun());
        out1001.setResGubun(request.getResGubun());
        out1001.setReserYn(request.getReserYn());
        out1001.setBunho(request.getBunhoLink());
        out1001.setHospCode(request.getHospCode());
        out1001.setOutHospCode(request.getOutHospcode());
        out1001.setNaewonDate(DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD));
        out1001.setJubsuNo(new BigDecimal(listTJubsuNo.get(0).toString()));
        out1001.setNaewonType("0");
        out1001.setNaewonYn("N");
        out1001.setJubsuGubun("01");
        out1001Repository.save(out1001);
        return out1001;
    }
}
