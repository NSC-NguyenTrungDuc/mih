
package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.service.ihis.handler.nuro.*;
import nta.med.service.ihis.handler.nuro.composite.OcsLoadInputAndVisibleControlHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.orca.handler.ORDERTRANProcessRequiHandler;

/**
 * @author dainguyen.
 */
public class NuroVerticle extends AbstractVerticle {

    public NuroVerticle() {
        super(NuroServiceProto.class, NuroServiceProto.getDescriptor());
    }

    @Override
    protected void doStart() throws Exception {
        registerHandler(NuroServiceProto.NuroMakeDeptComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroMakeDeptComboHandler.class));
        registerHandler(NuroServiceProto.NuroOutOrderStatusRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOutOrderStatusHandler.class));
        registerHandler(NuroServiceProto.NuroComboTimeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroComboTimeHandler.class));
        registerHandler(NuroServiceProto.NuroCboZipCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroCboZipCodeHandler.class));
        registerHandler(NuroServiceProto.NuroManagePatientRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroManagePatientHandler.class));
        registerHandler(NuroServiceProto.NuroSearchPatientInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroSearchPatientInfoHandler.class));
        registerHandler(NuroServiceProto.ComboListByCodeTypeRequest .class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboListByCodeTypeHandler.class));
        registerHandler(NuroServiceProto.NuroManagePatientUpdateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroManagePatientUpdateHandler.class));

        //[START] NUR2001U04
        registerHandler(NuroServiceProto.NuroPatientListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroPatientListHandler.class));
        registerHandler(NuroServiceProto.NuroNUR2001U04DepartmentListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroNUR2001U04DepartmentListHandler.class));
        registerHandler(NuroServiceProto.NuroNUR2001U04ComingStatusRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroNUR2001U04ComingStatusHandler.class));
        registerHandler(NuroServiceProto.NuroNUR2001U04ExistingKeyStatusRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroNUR2001U04ExistingKeyStatusHandler.class));
        registerHandler(NuroServiceProto.NuroNUR2001U04DoctorNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroNUR2001U04DoctorNameHandler.class));
        registerHandler(NuroServiceProto.NuroNUR2001U04ForeignKeyRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroNUR2001U04ForeignKeyHandler.class));
        registerHandler(NuroServiceProto.NuroNUR2001U04ComingStatusUpdateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroNUR2001U04ComingStatusUpdateHandler.class));
        registerHandler(NuroServiceProto.NuroNUR2001U04PatientInfoUpdateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroNUR2001U04PatientInfoUpdateHandler.class));
        registerHandler(NuroServiceProto.NuroProcOcsoDoctorChange2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroProcOcsoDoctorChange2Handler.class));
        registerHandler(NuroServiceProto.NuroNUR2001U04TransPatientInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroNUR2001U04TransPatientInfoHandler.class));
        registerHandler(NuroServiceProto.InitializeComboListItemRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(InitializeComboListItemHandler.class));
        registerHandler(NuroServiceProto.NUR2001U04CboDoctorRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2001U04CboDoctorHandler.class));
        registerHandler(NuroServiceProto.NUR2001U04SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2001U04SaveLayoutHandler.class));

        //[END] NUR2001U04

        //[START] NUR1001R98 - Inspection order form
        registerHandler(NuroServiceProto.NuroCheckBookingRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroCheckBookingHandler.class));
        registerHandler(NuroServiceProto.NuroInspectionOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroInspectionOrderHandler.class));
        // Remove NuroInspectionOrderCmtTextRequest
//        registerHandler(NuroServiceProto.NuroInspectionOrderCmtTextRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroInspectionOrderCmtTextHandler.class));
        registerHandler(NuroServiceProto.NuroInspectionOrderGetInfoTextRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroInspectionOrderGetInfoTextHandler.class));
        registerHandler(NuroServiceProto.NuroInspectionOrderGetReserMoveNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroInspectionOrderGetReserMoveNameHandler.class));
        registerHandler(NuroServiceProto.NuroInspectionOrderGetTelRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroInspectionOrderGetTelHandler.class));
        registerHandler(NuroServiceProto.NuroInspectionOrderGetMaxCodeNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroInspectionOrderGetMaxCodeNameHandler.class));
        registerHandler(NuroServiceProto.NuroNUR1001R98PageCountRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroNUR1001R98PageCountHandler.class));
        //test group
        registerHandler(NuroServiceProto.NUR1001R98LayReserInfoQueryEndRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR1001R98LayReserInfoQueryEndHandler.class));
        //[END] NUR1001R98 - Inspection order form

        //[START] NuroOUT1101Q01
        registerHandler(NuroServiceProto.NuroOUT1101Q01FwkDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1101Q01FwkDoctorInfoHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1101Q01GridInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1101Q01GridInfoHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1101Q01PrintNameInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1101Q01PrintNameInfoHandler.class));
        registerHandler(NuroServiceProto.JapanDateInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(JapanDateInfoHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1101Q01DoctorNameInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1101Q01DoctorNameInfoHandler.class));
        //[END] NuroOUT1101Q01

        //[START] OUT1001U01 - Register receipting out-paitent
        registerHandler(NuroServiceProto.NuroPatientInsuranceListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroPatientInsuranceListHandler.class));
        registerHandler(NuroServiceProto.NuroPatientDetailListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroPatientDetailListHandler.class));
        registerHandler(NuroServiceProto.NuroPatientCommentListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroPatientCommentListHandler.class));
        registerHandler(NuroServiceProto.NuroPatientReceptionHistoryListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroPatientReceptionHistoryListHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01LayLastCheckDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01LayLastCheckDateHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01LayGongbiCodeRequest .class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01LayGongbiCodeHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01BarCodeInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01BarCodeInfoHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01GetGroupKeyRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01GetGroupKeyHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01CheckDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01CheckDoctorHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01LoadOUT0105Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01LoadOUT0105Handler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01GetDbMaxJubsuNoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01GetDbMaxJubsuNoHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01CheckNaewonYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01CheckNaewonYnHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01CheckYRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01CheckYHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01DeleteJubsuDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01DeleteJubsuDataHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01LoadDoctorJinryoTimeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01LoadDoctorJinryoTimeHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01LoadCheckChojaeJpnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01LoadCheckChojaeJpnHandler.class));
        registerHandler(NuroServiceProto.NuroPatientGridViewRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroPatientGridViewHandler.class));
        registerHandler(NuroServiceProto.UpdateJubsuDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(UpdateJubsuDataHandler.class));
        
        //[END] OUT1001U01 - Register receipting out-paitent NuroOUT1001U01LoadDoctorJinryoTimeRequest

        //[START] RES1001U00 - Manage exam order
        registerHandler(NuroServiceProto.NuroRES1001U00UserNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00UserNameHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00DepartmentListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00DepartmentListHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00DoctorExamStatusRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00DoctorExamStatusHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00DoctorReservationStatusListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00DoctorReservationStatusListHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00ReservationScheduleCondition1ListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00ReservationScheduleCondition1ListHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00ReservationScheduleCondition2ListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00ReservationScheduleCondition2ListHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00AverageTimeListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00AverageTimeListHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00ReservationScheduleListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00ReservationScheduleListHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00TypeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00TypeHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00DoctorNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00DoctorNameHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00CheckingReservationRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00CheckingReservationHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00ReceptionNumberRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00ReceptionNumberHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00CheckingPatientExistenceRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00CheckingPatientExistenceHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00ReservationOut0123UpdateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00ReservationOut0123UpdateHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00ReservationOut0123InsertRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00ReservationOut0123InsertHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00ReservationOut1001InsertRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00ReservationOut1001InsertHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00CheckingHangmogCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00CheckingHangmogCodeHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00ReservationOut1001UpdateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00ReservationOut1001UpdateHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00ReservationOut0123DeleteRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00ReservationOut0123DeleteHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00ReservationOut1001DeleteRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00ReservationOut1001DeleteHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00DoctorReservationDateListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00DoctorReservationDateListHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00ReseredDataListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00ReseredDataListHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00ReserListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00ReserListHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00DoctorReserListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00DoctorReserListHandler.class));
        registerHandler(NuroServiceProto.NuroRES1001U00PRDoctorScheduleNewRequest .class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES1001U00PRDoctorScheduleNewHandler.class));
        registerHandler(NuroServiceProto.RES1001U00ReservationScheduleListGroupedRequest .class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(RES1001U00ReservationScheduleListGroupedHandler.class));
        registerHandler(NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(RES1001U00FrmModifyReserGrdRES1001Handler.class));
        registerHandler(NuroServiceProto.RES1001U00FrmModifyReserCboReserGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(RES1001U00FrmModifyReserCboReserGubunHandler.class));
        //registerHandler(NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001SavePerformerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(RES1001U00FrmModifyReserGrdRES1001SavePerformerHandler.class));
        registerHandler(NuroServiceProto.RES1001U00SaveLayoutItemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(RES1001U00SaveLayoutItemHandler.class));
        registerHandler(NuroServiceProto.RES1001U00FrmModifySaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(RES1001U00FrmModifySaveLayoutHandler.class));
        registerHandler(NuroServiceProto.RES1001U00PrIFSMakeYoyakuRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(RES1001U00PrIFSMakeYoyakuHandler.class));
        registerHandler(NuroServiceProto.RES1001U00MapingCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(RES1001U00MapingCodeHandler.class));
        registerHandler(NuroServiceProto.RES1001U00FbxHospCodeLinkRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(RES1001U00FbxHospCodeLinkHandler.class));
        registerHandler(NuroServiceProto.RES1001U00FbxHospCodeLinkDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(RES1001U00FbxHospCodeLinkDataValidatingHandler.class));
        registerHandler(NuroServiceProto.RES1001U00CheckUsingOrcaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(RES1001U00CheckUsingOrcaHandler.class));
        registerHandler(NuroServiceProto.RES1001U00CheckJinryoYnRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(RES1001U00CheckJinryoYnHandler.class));
        
        //[END] RES1001U00 - Manage exam order

        //[START] NuroOUT0101U02
        registerHandler(NuroServiceProto.NuroOUT0101U02GridCommentRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02GridCommentHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02GridBoheomRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02GridBoheomHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02GridGongbiListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02GridGongbiListHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02GridPatientRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02GridPatientHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02GetInsuranceRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02GetInsuranceCodeHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02GetBirthDayRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02GetBirthDayHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02GetTypeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02GetTypeHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02GetInsurance2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02GetInsurance2Handler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02GetTypeNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02GetTypeNameHandler.class));
        registerHandler(NuroServiceProto.NuroNuroOUT0101U02GetGaeinRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroNuroOUT0101U02GetGaeinHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02GetInsuranceNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02GetInsuranceNameHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02GetJohapRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02GetJohapHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02CheckExistsXRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02CheckExistsXHandler.class));
        registerHandler(NuroServiceProto.OUT0101U02SaveGridRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUT0101U02SaveGridHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02CheckExistsYRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02CheckExistsYHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02UpdatePatientRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02UpdatePatientHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02GetYRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02GetYHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02InsertBoheomRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02InsertBoheomHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02UpdateBoheomRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02UpdateBoheomHandler.class));

        registerHandler(NuroServiceProto.NuroOUT0101U02InsertGongbiListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02InsertGongbiListHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02UpdateGongbiListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02UpdateGongbiListHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02DeleteGongbiRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02DeleteGongbiHandler.class));

        registerHandler(NuroServiceProto.NuroOUT0101U02DeleteBoheomRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02DeleteBoheomHandler.class));
        registerHandler(NuroServiceProto.NuroOUT0101U02GongbiListGetYRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT0101U02GongbiListGetYHandler.class));
        registerHandler(NuroServiceProto.OUT0101U02ComboListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101U02ComboListHandler.class));
        registerHandler(NuroServiceProto.OUT0101U02GridViewRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101U02GridViewHandler.class));
        registerHandler(NuroServiceProto.OUT0101U02CheckAndInsertPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101U02CheckAndInsertPatientHandler.class));
        registerHandler(NuroServiceProto.OUT0101U02CheckAndUpdatePatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101U02CheckAndUpdatePatientHandler.class));
        registerHandler(NuroServiceProto.OUT0101U02GetAndInsertBoheomRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101U02GetAndInsertBoheomHandler.class));
        registerHandler(NuroServiceProto.OUT0101U02GetAndUpdateBoheomRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101U02GetAndUpdateBoheomHandler.class));
        registerHandler(NuroServiceProto.OUT0101U02GetAndInsertGongbiListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101U02GetAndInsertGongbiListHandler.class));
        registerHandler(NuroServiceProto.OUT0101U02GetPatientCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101U02GetPatientCodeHandler.class));
        //[END] NuroOUT0101U02

        //[START] NuroRES0102U00GrdRES0103
        registerHandler(NuroServiceProto.NuroRES0102U00GrdRES0102Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00GrdRES0102Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00GrdRES0103Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00GrdRES0103Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00CboDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00CboDoctorItemHandler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00CboGwaRoomRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00CboGwaRoomHandler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00ChkHyujinRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00ChkHyujinHandler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00CboGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00CboGwaHandler.class));
        registerHandler(NuroServiceProto.CboAvgTimeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CboAvgTimeHandler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00GridDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00GridDoctorHandler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00GetDoctorByJinryoDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00GetDoctorByJinryoDateHandler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00GetDoctorByStarDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00GetDoctorByStarDateHandler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00GetDoctorInBetweenDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00GetDoctorInBetweenDateHandler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00CheckDoctorReq1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00CheckDoctorHandler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00CheckDoctorReq2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00CheckDoctor2Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00CheckDoctorReq3Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00CheckDoctor3Handler.class));

        registerHandler(NuroServiceProto.NuroRES0102U00InsertRES0104Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00InsertRES0104Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00UpdateRES0104Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00UpdateRES0104Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00DeleteRES0104Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00DeleteRES0104Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00InsertRES0103Req1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00InsertRES01031Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00InsertRES0103Req2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00InsertRES01032Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00DeleteRES0103Req1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00DeleteRES01031Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00DeleteRES0103Req2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00DeleteRES01032Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00DeleteRES0102Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00DeleteRES0102Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00UpdateRES0102Req1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00UpdateRES01021Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00UpdateRES0102Req3Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00UpdateRES01023Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00InsertRES0102Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00InsertRES0102Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00UpdateRES0103Req1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00UpdateRES01031Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00UpdateRES0103Req2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00UpdateRES01032Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00UpdateRES0102Req2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00UpdateRES01022Handler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00DeleteRES0102Req2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00DeleteRES0102Req2Handler.class));

        registerHandler(NuroServiceProto.NuroRES0102U00GetDataGridViewRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00GetDataGridViewHandler.class));
        registerHandler(NuroServiceProto.NuroRES0102U00SaveScheduleRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRES0102U00SaveScheduleHandler.class));
        registerHandler(NuroServiceProto.NuroRes0102u00InitCboListItemRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroRes0102u00InitCboListItemHandler.class));
        //[END] NuroRES0102U00GrdRES0103

        //[START] OUT1001U01
        registerHandler(NuroServiceProto.NuroOUT1001U01CheckY2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01CheckY2Handler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01CheckY3Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01CheckY3Handler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01GetOut1001SeqRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01GetOut1001SeqHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01InsertJubsuRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01InsertJubsuHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01InsertTableOUT1002Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01InsertTableOUT1002Handler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01GetGubunNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01GetGubunNameHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01UpdateTableOUT1001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01UpdateTableOUT1001Handler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01DeleteInTableOUT1002Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01DeleteInTableOUT1002Handler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01GetDepartmentRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01GetDepartmentHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01GetDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01GetDoctorHandler.class));
        registerHandler(NuroServiceProto.NuroOUT1001U01GetTypeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOUT1001U01GetTypeHandler.class));
        registerHandler(NuroServiceProto.NuroOut1001U01CheckDoctorScheduleRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroOut1001U01CheckDoctorScheduleHandler.class));
        //[END] OUT1001U01

        //[START] NUR1001R00
        registerHandler(NuroServiceProto.NuroNUR1001R00GetGwaDoctorTempListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroNUR1001R00GetGwaDoctorTempListHandler.class));
        registerHandler(NuroServiceProto.NuroNUR1001R00GetTempListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroNUR1001R00GetTempListHandler.class));

        //[END] NUR1001R00

        //[START] OUT1001P01
        registerHandler(NuroServiceProto.OUT1001P01GrdOUT1001Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT1001P01GrdOUT1001Handler.class));
        registerHandler(NuroServiceProto.OUT1001P01FindboxValidatingRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OUT1001P01FindboxValidatingHandler.class));
        registerHandler(NuroServiceProto.OUT1001P01PrOutChangeGwaDoctorRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT1001P01PrOutChangeGwaDoctorHandler.class));
        //[END] OUT1001P01

        //[START] NURO LIB
        registerHandler(NuroServiceProto.NuroGetLastGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroGetLastGubunHandler.class));
        registerHandler(NuroServiceProto.NuroGetRecentlyDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroGetRecentlyDoctorHandler.class));
        registerHandler(NuroServiceProto.NuroGetGubunNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroGetGubunNameHandler.class));
        registerHandler(NuroServiceProto.NuroGetGwaNameBAS0260Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroGetGwaNameBAS0260Handler.class));
        registerHandler(NuroServiceProto.NuroGetDoctorNameBAS0270Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroGetDoctorNameBAS0270Handler.class));
        registerHandler(NuroServiceProto.NuroChkGetBunhoBySujinRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroChkGetBunhoBySujinHandler.class));
        registerHandler(NuroServiceProto.NuroChkGetGongbiYNRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroChkGetGongbiYNHandler.class));
        registerHandler(NuroServiceProto.NuroLoadTableReserYNRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroLoadTableReserYNHandler.class));
        registerHandler(NuroServiceProto.NuroGetZipNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroGetZipNameHandler.class));
        registerHandler(NuroServiceProto.NuroChkGetWonyoiYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NuroChkGetWonyoiYnHandler.class));
        //[END] NURO LIB

        //[START] OCS.lib
        registerHandler(NuroServiceProto.OcsLoadInputControlRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OcsLoadInputControlHandler.class));
        registerHandler(NuroServiceProto.OcsLoadVisibleControlRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OcsLoadVisibleControlHandler.class));
        registerHandler(NuroServiceProto.OcsLoadInputTabRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OcsLoadInputTabHandler.class));
        registerHandler(NuroServiceProto.OcsOrderBizLoadComboDataSourceRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OcsOrderBizLoadComboDataSourceHandler.class));
        //[END] OCS.lib

        // OCS1003P01
        registerHandler(NuroServiceProto.OCS1003P01GrdPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS1003P01GrdPatientHandler.class));
        registerHandler(NuroServiceProto.OCS1003P01MakeInputGubunTabRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OCS1003P01MakeInputGubunTabHandler.class));
        // OCS1003P01
        //[START] OUT0101Q01
        registerHandler(NuroServiceProto.OUT0101Q01GrdPatientListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101Q01GrdPatientListHandler.class));
        registerHandler(NuroServiceProto.OUT0101Q01CboSexRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101Q01CboSexHandler.class));
        //[END] OUT0101Q01
        // START OUT0106U00
        registerHandler(NuroServiceProto.OUT0106U00GridListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0106U00GridListHandler.class));
        registerHandler(NuroServiceProto.OUT0106U00PatientListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0106U00PatientListHandler.class));
        registerHandler(NuroServiceProto.OUT0106U00PatientInfoNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0106U00PatientInfoNameHandler.class));
        registerHandler(NuroServiceProto.OUT0106U00SaveCommentsRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0106U00SaveCommentsHandler.class));
        // END OUT0106U00

        registerHandler(NuroServiceProto.OUT0101U04SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101U04SaveLayoutHandler.class));
        registerHandler(NuroServiceProto.OUT0101U04TxtZipCode2DataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101U04TxtZipCode2DataValidatingHandler.class));
        
        // START ORDERTRANS
        registerHandler(NuroServiceProto.ORDERTRANSGrdHokenRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSGrdHokenHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSGrdINP2004Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSGrdINP2004Handler.class));
        registerHandler(NuroServiceProto.ORDERTRANSGrdSiksaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSGrdSiksaHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSGrdOutSangRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSGrdOutSangHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSGrdWoichulRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSGrdWoichulHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSLayOut0101Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSLayOut0101Handler.class));
        registerHandler(NuroServiceProto.ORDERTRANSGrdCommentsRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSGrdCommentsHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSFwkFindRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSFwkFindHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSLayCommonRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSLayCommonHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSPrIfsSiksaInputTestRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSPrIfsSiksaInputTestHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSSangSendAllRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSSangSendAllHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSGrdEditRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSGrdEditHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSGrdListNonSendYnRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSGrdListNonSendYnHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSGrdListSendYnRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSGrdListSendYnHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSGrdEditRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSGrdEditHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSGrdEditIGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSGrdEditIGubunHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSGrdListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSGrdListHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSExecPrOutCheckOrderEndRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSExecPrOutCheckOrderEndHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSGrdGongbiListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSGrdGongbiListHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANProcessRequiRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANProcessRequiHandler.class));
        registerHandler(NuroServiceProto.OrderTransMisaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OrderTransMisaHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSMisaGetHangmogRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSMisaGetHangmogHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANSMisaTranferRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSMisaTranferHandler.class));
        
        registerHandler(NuroServiceProto.ORDERTRANSAPITransferOrdersRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSAPITransferOrdersHandler.class));
        // END ORDERTRANS
        
        registerHandler(NuroServiceProto.OUT1001R01GrdListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT1001R01GrdListHandler.class));
        registerHandler(NuroServiceProto.OUT1001R01LayOut0101Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT1001R01LayOut0101Handler.class));
        registerHandler(NuroServiceProto.ORDERTRANOcs1003UpdateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANOcs1003UpdateHandler.class));
        registerHandler(NuroServiceProto.ORDERTRANPRMakeIFS1004Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANPRMakeIFS1004Handler.class));
		 // START NURO.OUT1001P03
        registerHandler(NuroServiceProto.OUT1001P03BunhoListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT1001P03BunhoListHandler.class));
        // END NURO.OUT1001P03
        //[START] OUT1001P03
        registerHandler(NuroServiceProto.OUT1001P03PaBeforeBoxRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT1001P03PaBeforeBoxHandler.class));
        registerHandler(NuroServiceProto.OUT1001P03GrdBeforeJubsuRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT1001P03GrdBeforeJubsuHandler.class));
        registerHandler(NuroServiceProto.OUT1001P03GrdBeforeOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT1001P03GrdBeforeOrderHandler.class));
        registerHandler(NuroServiceProto.OUT1001P03GrdAfterOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT1001P03GrdAfterOrderHandler.class));
        registerHandler(NuroServiceProto.OUT1001P03GrdAfterJubsuRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT1001P03GrdAfterJubsuHandler.class));
        registerHandler(NuroServiceProto.OUT1001P03ProcessRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT1001P03ProcessHandler.class));
        //[END] OUT1001P03
        
        //[START] OUT0101Phr
        registerHandler(NuroServiceProto.OUT0101PhrInsertRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101PhrInsertHandler.class));
        //[END] OUT0101Phr
        
		//[START] ORDERTRANSangTransRequest
		registerHandler(NuroServiceProto.ORDERTRANSangTransRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANSangTransHandler.class));
		//[END] ORDERTRANSangTransRequest
		    
		//[START] ORDERTRANOrderTransRequest
		registerHandler(NuroServiceProto.ORDERTRANOrderTransRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANOrderTransHandler.class));
		//[END] ORDERTRANOrderTransRequest

        registerHandler(NuroServiceProto.NUROAccountForcedEndRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUROAccountForcedEndHandler.class));
        
        //[START] ORDERTRANInsertOcsTempRequest
  		registerHandler(NuroServiceProto.ORDERTRANInsertOcsTempRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ORDERTRANInsertOcsTempHandler.class));
  		//[END] ORDERTRANInsertOcsTempRequest
  		
  		 //[START] NuroORDERTRANSUpdateOCS1003Request
  		registerHandler(NuroServiceProto.NuroORDERTRANSUpdateOCS1003Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NuroORDERTRANSUpdateOCS1003Handler.class));
  		 //[END] NuroORDERTRANSUpdateOCS1003Request
  		
  		//[START] RES1001R00
  			registerHandler(NuroServiceProto.RES1001R00PrintBookingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(RES1001R00PrintBookingHandler.class));
  	    //[END] RES1001R00
  			
  		//[START] NUR2016U02
  			registerHandler(NuroServiceProto.NUR2016U02GrdListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2016U02GrdListHandler.class));
  			registerHandler(NuroServiceProto.NUR2016U02DeleteLinkPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2016U02DeleteLinkPatientHandler.class));
  	    //[END] NUR2016U02	
  			
  		//[START] NUR2016U03
  			registerHandler(NuroServiceProto.NUR2016U03TranferRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2016U03TranferHandler.class));
  	    //[END] NUR2016U03
  			
  		//[START] RES1001U01
  			registerHandler(NuroServiceProto.RES1001U01BookingClinicReferRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(RES1001U01BookingClinicReferHandler.class));
  		//[END] RES1001U01

        //[START] NUR2016
        registerHandler(NuroServiceProto.NUR2016Q00GrdHospListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2016Q00GrdHospListHandler.class));
        registerHandler(NuroServiceProto.NUR2016Q00GrdPatientListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2016Q00GrdPatientListHandler.class));
        registerHandler(NuroServiceProto.NUR2016Q00LinkPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2016Q00LinkPatientHandler.class));
        registerHandler(NuroServiceProto.NUR2016Q00CreateTempIDRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2016Q00CreateTempIDHandler.class));
        //[END] NUR2016
        
      //[START] NUR-OUT0101U02
        registerHandler(NuroServiceProto.OUT0101U02GetHospitalInfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101U02GetHospitalInfoHandler.class));
        registerHandler(NuroServiceProto.NUR2015U01ReservationPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2015U01ReservationPatientHandler.class));
        registerHandler(NuroServiceProto.NUR2015U01GetDataFromNaewonRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2015U01GetDataFromNaewonHandler.class));
      //[END] NUR-OUT0101U02
        
      //[START] KCCK API
//        registerHandler(NuroServiceProto.KCCKAPIGetScheduleDocTorRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(KCCKAPIGetScheduleDocTorHandler.class));
        //registerHandler(NuroServiceProto.ScheduleDocTorRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ScheduleDoctorHandler.class));
        registerHandler(NuroServiceProto.KcckApiGetDoctorsRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(KcckApiGetDoctorsHandler.class));
        registerHandler(NuroServiceProto.KcckApiSearchDoctorsRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(KcckApiSearchDoctorsHandler.class));
        registerHandler(NuroServiceProto.KcckApiBookingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(KcckApiBookingHandler.class));
        registerHandler(NuroServiceProto.KcckApiChangeBookingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(KcckApiChangeBookingHandler.class));
        registerHandler(NuroServiceProto.KcckApiCancelBookingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(KcckApiCancelBookingHandler.class));
      //[END] KCCK API
      //[START] NUR2015U01
        registerHandler(NuroServiceProto.NUR2015U01EmrRecordUpdateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2015U01EmrRecordUpdateHandler.class));
        registerHandler(NuroServiceProto.NUR2015U01GrdOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2015U01GrdOrderHandler.class));
      //[END] NUR2015U01  
        
        
      //Merge requests OcsLoadInputControl and OcsLoadVisibleControl
        registerHandler(NuroServiceProto.OcsLoadInputAndVisibleControlRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OcsLoadInputAndVisibleControlHandler.class)); 
        
      //KCCK MSS API KC08
        registerHandler(NuroServiceProto.PatientInfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(PatientInfoHandler.class));
        
      //[START] NUR2016U02Nuro
        registerHandler(NuroServiceProto.NUR2016U02NuroPatientListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2016U02NuroPatientListHandler.class));
        registerHandler(NuroServiceProto.NUR2016U02TranferRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2016U02TranferHandler.class));
      //[END] NUR2016U02Nuro
    
        registerHandler(NuroServiceProto.OUT0101U02ChangePWDRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101U02ChangePWDHandler.class));
        registerHandler(NuroServiceProto.NUR2016CheckExitsEMRLinkRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2016CheckExitsEMRLinkHandler.class));
        registerHandler(NuroServiceProto.NUR2016DeleteEMRLinkRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2016DeleteEMRLinkHandler.class));
        registerHandler(NuroServiceProto.NUR2016PublishEMRLinkRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NUR2016PublishEMRLinkHandler.class));
        registerHandler(NuroServiceProto.SearchBookingScheduleRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SearchBookingScheduleHandler.class));
        
        registerHandler(NuroServiceProto.RES1001U00CheckDuplicateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(RES1001U00CheckDuplicateHandler.class));
        
        registerHandler(NuroServiceProto.OUT0101U02PatientExportRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101U02PatientExportHandler.class));
        registerHandler(NuroServiceProto.OUT0101U02ImportPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OUT0101U02ImportPatientHandler.class));
        
        registerHandler(NuroServiceProto.RES1001U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(RES1001U00SaveLayoutHandler.class));
      //[START] Send payment to patient
        registerHandler(NuroServiceProto.BIL0102U00GetHospInfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BIL0102U00GetHospInfoHandler.class));
        registerHandler(NuroServiceProto.BIL0102U00GetPatientEmailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BIL0102U00GetPatientEmailHandler.class));
        registerHandler(NuroServiceProto.BIL0102U00GetMailTemplateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BIL0102U00GetMailTemplateHandler.class));
        registerHandler(NuroServiceProto.BIL0102U00GetExaminationInfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BIL0102U00GetExaminationInfoHandler.class));
        registerHandler(NuroServiceProto.BIL0102U00SendEmailPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BIL0102U00SendEmailPatientHandler.class));
      //[END] Send payment to patient
    }

    @Override
    protected void doStop() throws Exception {

    }
}
