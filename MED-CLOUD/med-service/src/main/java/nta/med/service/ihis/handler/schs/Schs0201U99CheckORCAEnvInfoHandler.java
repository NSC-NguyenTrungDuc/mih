package nta.med.service.ihis.handler.schs;

import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.res.Res0103Repository;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.Schs0201U99CheckORCAEnvInfoRequest;
import nta.med.service.ihis.proto.SchsServiceProto.Schs0201U99CheckORCAEnvInfoResponse;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.Date;
import java.util.List;

@Service
@Scope("prototype")
public class Schs0201U99CheckORCAEnvInfoHandler extends ScreenHandler<SchsServiceProto.Schs0201U99CheckORCAEnvInfoRequest, SchsServiceProto.Schs0201U99CheckORCAEnvInfoResponse> {

	private static final Log LOGGER = LogFactory.getLog(Schs0201U99CheckORCAEnvInfoHandler.class);
	
    @Resource
    private Sch0201Repository sch0201Repository;

    @Resource
    private Bas0102Repository bas0102Repository;

    @Resource
    private Out1001Repository out1001Repository;

    @Resource
    private Ifs0003Repository ifs0003Repository;

    @Resource
    private Res0103Repository res0103Repository;

    @Override
    @Transactional(readOnly = true)
    public Schs0201U99CheckORCAEnvInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
                                                      Schs0201U99CheckORCAEnvInfoRequest request) throws Exception {
        SchsServiceProto.Schs0201U99CheckORCAEnvInfoResponse.Builder response = SchsServiceProto.Schs0201U99CheckORCAEnvInfoResponse.newBuilder();

        String hospCode = request.getHospCode();
        String codeType = request.getCodeType();
        String doctor = request.getDoctor();
        String gwa = request.getGwa();
        String bunhoLink = request.getBunhoLink();
        Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
        String hangmogCode = request.getHangmogCode();
        String jundalTable = request.getJundalTable();
        String jundalPart = request.getJundalPart();
        String reserDate = request.getReserDate();
        String reserTime = request.getReserTime();

        //validate hospital code
        if (sch0201Repository.isOrderEffected(hospCode, hangmogCode, reserDate)) {
            //validate number order server care
			String errorCode = validateNumberOder(hospCode, jundalTable, jundalPart, reserDate, reserTime);
//
			if(!StringUtils.isEmpty(errorCode)){
				response.setErrCode(errorCode);
				return response.build();
			}

            //check using ORCA

            List<Bas0102> checkAccTypes = bas0102Repository.findByHospCodeAndCodeType(hospCode, AccountingConfig.ACCT_TYPE.getValue());
            LOGGER.info("Schs0201U99CheckORCAEnvInfoHandler: checkAccTypes"+ checkAccTypes.size());
            if (CollectionUtils.isEmpty(checkAccTypes)) {
                response.setErrCode("6");
                return response.build();
            }

            //check exist patient in other clinic
            List<Double> pkout1001 = out1001Repository.getSchs0201U99CheckInsert(hospCode, bunhoLink, naewonDate, doctor, gwa);
            LOGGER.info("Schs0201U99CheckORCAEnvInfoHandler: pkout1001"+ pkout1001);
            if (!CollectionUtils.isEmpty(pkout1001)) {
                response.setErrCode("0");
                return response.build();
            }

            //validate booking examination
            String tChk = res0103Repository.getNuroRES1001U00CheckingReservation(hospCode, getHospitalCode(vertx, sessionId), doctor,
                    request.getReserDate(), request.getReserTime(), request.getInputGubun(), true);
            LOGGER.info("Schs0201U99CheckORCAEnvInfoHandler: tChk"+ tChk);
            if (!StringUtils.isEmpty(tChk)) {
                if ("1".equals(tChk)
                        || "2".equals(tChk)) {
                    response.setErrCode("3");
                    return response.build();
                }
            }

            //mapping code (ORCA)
            List<Ifs0003> listIfs0003Gwa = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode
                    , AccountingConfig.IF_ORCA_GWA.getValue(), request.getGwa());


            List<Ifs0003> listIfs0003Doctor = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode
                    , AccountingConfig.IF_ORCA_DOCTOR.getValue(), doctor.substring(2, doctor.length()));

            if (CollectionUtils.isEmpty(listIfs0003Gwa) && CollectionUtils.isEmpty(listIfs0003Doctor)) {
                response.setErrCode("4");
                return response.build();
            }

            String gwaResponse = "";
            String doctorResponse = "";

            if (!CollectionUtils.isEmpty(listIfs0003Gwa)) {
                gwaResponse = listIfs0003Gwa.get(0).getIfCode();
            }

            if (!CollectionUtils.isEmpty(listIfs0003Doctor)) {
                doctorResponse = listIfs0003Doctor.get(0).getIfCode();
            }
            String orcaIp = "";
            String orceUser = "";
            String orcaPassword = "";
            String accType = "";

            LOGGER.info("Schs0201U99CheckORCAEnvInfoHandler: orcaIp"+ orcaIp);
            LOGGER.info("Schs0201U99CheckORCAEnvInfoHandler: orceUser"+ orceUser);
            LOGGER.info("Schs0201U99CheckORCAEnvInfoHandler: orcaPassword"+ orcaPassword);
            LOGGER.info("Schs0201U99CheckORCAEnvInfoHandler: accType"+ accType);
            SchsModelProto.Schs0201U99CheckORCAEnvInfoInfo info = SchsModelProto.Schs0201U99CheckORCAEnvInfoInfo.newBuilder()
                    .setIfCodeGwa(gwaResponse)
                    .setIfCodeDoctor(doctorResponse)
                    .setOrcaIp(orcaIp)
                    .setOrcaUser(orceUser)
                    .setOrcaPassword(orcaPassword)
                    .setAccType(accType)
                    .build();
            response.addLstData(info);
        } else {
            //hospital does not provider services of this order
            response.setErrCode("1");
            LOGGER.info("Schs0201U99CheckORCAEnvInfoHandler has errCode 1");
            return response.build();
        }
        response.setErrCode("0");
        return response.build();
    }

    private String validateNumberOder(String hospCode, String jundalTable, String jundalPart, String reserDate, String reserTime) {

        String inWon = sch0201Repository.getSchTotalInWonByTime(hospCode, jundalTable, jundalPart, reserDate, reserTime);
        String outWon = sch0201Repository.getSchTotalOutWonByTime(hospCode, jundalTable, jundalPart, reserDate, reserTime);
        Integer totalBookingIn = CommonUtils.parseInteger(inWon.split("/")[0]);
        Integer maxLabSlot = CommonUtils.parseInteger(inWon.split("/")[1]);
        Integer totalBookingOut = CommonUtils.parseInteger(outWon.split("/")[0]);
        Integer maxLabOut = CommonUtils.parseInteger(outWon.split("/")[1]);

        LOGGER.info("Schs0201U99CheckORCAEnvInfoHandler validateNumberOder totalBookingIn:" + totalBookingIn);
        LOGGER.info("Schs0201U99CheckORCAEnvInfoHandler validateNumberOder maxLabSlot:" + maxLabSlot);
        LOGGER.info("Schs0201U99CheckORCAEnvInfoHandler validateNumberOder totalBookingOut:" + totalBookingOut);
        LOGGER.info("Schs0201U99CheckORCAEnvInfoHandler validateNumberOder maxLabOut:" + maxLabOut);

        if (
        ((totalBookingIn + totalBookingOut) >= maxLabSlot)
                || (totalBookingOut >= maxLabOut)) {
            return "2";
        }
        return null;
    }

}

