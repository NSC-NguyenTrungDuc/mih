package nta.med.service.ihis.handler.ocso;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class OcsoOCS1003P01UpdateDataOCS1003Handler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01UpdateDataOCS1003Request, SystemServiceProto.UpdateResponse>{
private static final Log logger = LogFactory.getLog(OcsoOCS1003P01UpdateDataOCS1003Handler.class);
	
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01UpdateDataOCS1003Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = updateOcs1003(request, getHospitalCode(vertx, sessionId));
        response.setResult(result);
		return response.build();
	}
	
	private boolean updateOcs1003(OcsoServiceProto.OcsoOCS1003P01UpdateDataOCS1003Request request, String hospCode) {
			Double suryang = CommonUtils.parseDouble(request.getSuryang());
			Double dv = CommonUtils.parseDouble(request.getDv());
			Double nalsu = CommonUtils.parseDouble(request.getNalsu());
			Date hopeDate = DateUtil.toDate(request.getHopeDate(), DateUtil.PATTERN_YYMMDD);
			Double dv1 = CommonUtils.parseDouble(request.getDv1());
			Double dv2 = CommonUtils.parseDouble(request.getDv2());
			Double dv3 = CommonUtils.parseDouble(request.getDv3());
			Double dv4 = CommonUtils.parseDouble(request.getDv4());
			Double dv5 = CommonUtils.parseDouble(request.getDv5());
			Double dv6 = CommonUtils.parseDouble(request.getDv6());
			Double dv7 = CommonUtils.parseDouble(request.getDv7());
			Double dv8 = CommonUtils.parseDouble(request.getDv8());
			Double bomSourceKey = CommonUtils.parseDouble(request.getBomSourceKey());
			Date nurseConfirmDate = DateUtil.toDate(request.getNurseConfirmDate(), DateUtil.PATTERN_YYMMDD);
			Double sortFkocskey = CommonUtils.parseDouble(request.getSortFkocskey());
			Double groupSer = CommonUtils.parseDouble(request.getGroupSer());
			Double pkocs1003 = CommonUtils.parseDouble(request.getPkocskey());
			if( ocs1003Repository.updateOcsoOCS1003P01UpdateDataOCS1003IgnoreActingDate(new Date(), request.getUpdId(), request.getOrderGubun(),suryang, request.getOrdDanui(),
					request.getDvTime(), dv, nalsu, request.getJusa(), request.getBogyongCode(), request.getEmergency(), request.getJaeryoJundalYn(),
					request.getJundalTable(), request.getJundalPart(), request.getMovePart(), request.getMuhyo(), request.getPortableYn(),
					request.getAntiCancerYn(), request.getDcYn(), request.getDcGubun(), request.getBannabYn(), request.getBannabConfirm(),
					request.getSutakYn(), request.getPowderYn(), hopeDate, request.getHopeTime(), dv1, dv2, dv3, dv4, dv5, dv6, dv7, dv8, 
					request.getMixGroup(), request.getOrderRemark(), request.getNurseRemark(), request.getBomOccurYn(), bomSourceKey, 
					request.getNurseConfirmUser(), nurseConfirmDate, request.getNurseConfirmTime(), request.getDangilGumsaOrderYn(),
					request.getDangilGumsaResultYn(), request.getHomeCareYn(), request.getRegularYn(), request.getHubalChangeYn(),
					request.getPharmacy(), request.getJusaSpdGubun(), request.getDrgPackYn(), sortFkocskey, request.getWonyoiOrderYn(),
					request.getImsiDrugYn(), request.getSpecimenCode(), request.getGeneralDispYn(), request.getBogyongCodeSub(),
					groupSer, pkocs1003, hospCode) > 0)
				return true;
				return false;
	}

}
