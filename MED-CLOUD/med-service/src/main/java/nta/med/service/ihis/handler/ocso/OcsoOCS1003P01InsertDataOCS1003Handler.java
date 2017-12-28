package nta.med.service.ihis.handler.ocso;

import java.math.BigDecimal;
import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.ocs.Ocs1003;
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
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class OcsoOCS1003P01InsertDataOCS1003Handler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01InsertDataOCS1003Request, SystemServiceProto.UpdateResponse>{
private static final Log logger = LogFactory.getLog(OcsoOCS1003P01InsertDataOCS1003Handler.class);
	
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01InsertDataOCS1003Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = insertOcs1003(request, getHospitalCode(vertx, sessionId));
        response.setResult(result);
		return response.build();
	}
	
	private boolean insertOcs1003(OcsoServiceProto.OcsoOCS1003P01InsertDataOCS1003Request request, String hospCode) {
			Ocs1003 ocs1003 = new Ocs1003();
			if(!StringUtils.isEmpty(request.getSysDate())) {
				Date sysDate = DateUtil.toDate(request.getSysDate(), DateUtil.PATTERN_YYMMDD);
				ocs1003.setSysDate(sysDate);
			}
			if(!StringUtils.isEmpty(request.getSysId())) {
				ocs1003.setSysId(request.getSysId());
			}
			ocs1003.setUpdDate(new Date());
			if(!StringUtils.isEmpty(request.getUpdId())) {
				ocs1003.setUpdId(request.getUpdId());
			}
			ocs1003.setHospCode(hospCode);
			if(!StringUtils.isEmpty(request.getPkocs1003())) {
				Double pkocs1003 = CommonUtils.parseDouble(request.getPkocs1003());
				ocs1003.setPkocs1003(pkocs1003);
			}
			if(!StringUtils.isEmpty(request.getBunho())) {
				ocs1003.setBunho(request.getBunho());
			}
			if(!StringUtils.isEmpty(request.getOrderDate())) {
				Date orderDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
				ocs1003.setOrderDate(orderDate);
			}
			if(!StringUtils.isEmpty(request.getGwa())) {
				ocs1003.setGwa(request.getGwa());
			}
			if(!StringUtils.isEmpty(request.getDoctor())) {
				ocs1003.setDoctor(request.getDoctor());
			}
			if(!StringUtils.isEmpty(request.getNaewonType())) {
				ocs1003.setNaewonType(request.getNaewonType());
			}
			if(!StringUtils.isEmpty(request.getInputId())) {
				ocs1003.setInputId(request.getInputId());
			}
			if(!StringUtils.isEmpty(request.getInputPart())) {
				ocs1003.setInputPart(request.getInputPart());
			}
			if(!StringUtils.isEmpty(request.getInputGubun())) {
				ocs1003.setInputGubun(request.getInputGubun());
			}
			if(!StringUtils.isEmpty(request.getSeq())) {
				Double seq = CommonUtils.parseDouble(request.getSeq());
				ocs1003.setSeq(seq);
			}
			if(!StringUtils.isEmpty(request.getHangmogCode())) {
				ocs1003.setHangmogCode(request.getHangmogCode());
			}
			if(!StringUtils.isEmpty(request.getGroupSer())) {
				Double groupSer = CommonUtils.parseDouble(request.getGroupSer());
				ocs1003.setGroupSer(groupSer);
			}
			if(!StringUtils.isEmpty(request.getSlipCode())) {
				ocs1003.setSlipCode(request.getSlipCode());
			}
			if(!StringUtils.isEmpty(request.getNdayYn())) {
				ocs1003.setNdayYn(request.getNdayYn());
			}
			if(!StringUtils.isEmpty(request.getOrderGubun())) {
				ocs1003.setOrderGubun(request.getOrderGubun());
			}
			if(!StringUtils.isEmpty(request.getSpecimenCode())) {
				ocs1003.setSpecimenCode(request.getSpecimenCode());
			}
			if(!StringUtils.isEmpty(request.getSuryang())) {
				Double suryang = CommonUtils.parseDouble(request.getSuryang());
				ocs1003.setSuryang(suryang);
			}
			if(!StringUtils.isEmpty(request.getOrdDanui())) {
				ocs1003.setOrdDanui(request.getOrdDanui());
			}
			if(!StringUtils.isEmpty(request.getDvTime())) {
				ocs1003.setDvTime(request.getDvTime());
			}
			if(!StringUtils.isEmpty(request.getDv())) {
				Double dv = CommonUtils.parseDouble(request.getDv());
				ocs1003.setDv(dv);
			}
			if(!StringUtils.isEmpty(request.getNalsu())) {
				Double nalsu = CommonUtils.parseDouble(request.getNalsu());
				ocs1003.setNalsu(nalsu);
			}
			if(!StringUtils.isEmpty(request.getJusa())) {
				ocs1003.setJusa(request.getJusa());
			}
			if(!StringUtils.isEmpty(request.getBogyongCode())) {
				ocs1003.setBogyongCode(request.getBogyongCode());
			}
			if(!StringUtils.isEmpty(request.getEmergency())) {
				ocs1003.setEmergency(request.getEmergency());
			}
			if(!StringUtils.isEmpty(request.getJaeryoJundalYn())) {
				ocs1003.setJaeryoJundalYn(request.getJaeryoJundalYn());
			}
			if(!StringUtils.isEmpty(request.getJundalTable())) {
				ocs1003.setJundalTable(request.getJundalTable());
			}
			if(!StringUtils.isEmpty(request.getJundalPart())) {
				ocs1003.setJundalPart(request.getJundalPart());
			}
			if(!StringUtils.isEmpty(request.getMovePart())) {
				ocs1003.setMovePart(request.getMovePart());
			}
			if(!StringUtils.isEmpty(request.getMuhyo())) {
				ocs1003.setMuhyo(request.getMuhyo());
			}
			if(!StringUtils.isEmpty(request.getPortableYn())) {
				ocs1003.setPortableYn(request.getPortableYn());
			}
			if(!StringUtils.isEmpty(request.getAntiCancerYn())) {
				ocs1003.setAntiCancerYn(request.getAntiCancerYn());
			}
			if(!StringUtils.isEmpty(request.getPay())) {
				ocs1003.setPay(request.getPay());
			}
			if(!StringUtils.isEmpty(request.getReserDate())) {
				Date reserDate = DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD);
				ocs1003.setReserDate(reserDate);
			}
			if(!StringUtils.isEmpty(request.getReserTime())) {
				ocs1003.setReserTime(request.getReserTime());
			}
			if(!StringUtils.isEmpty(request.getDcYn())) {
				ocs1003.setDcYn(request.getDcYn());
			}
			if(!StringUtils.isEmpty(request.getDcGubun())) {
				ocs1003.setDcGubun(request.getDcGubun());
			}
			if(!StringUtils.isEmpty(request.getBannabYn())) {
				ocs1003.setBannabYn(request.getBannabYn());
			}
			if(!StringUtils.isEmpty(request.getBannabConfirm())) {
				ocs1003.setBannabConfirm(request.getBannabConfirm());
			}
			if(!StringUtils.isEmpty(request.getActDoctor())) {
				ocs1003.setActDoctor(request.getActDoctor());
			}
			if(!StringUtils.isEmpty(request.getActGwa())) {
				ocs1003.setActGwa(request.getActGwa());
			}
			if(!StringUtils.isEmpty(request.getActBuseo())) {
				ocs1003.setActBuseo(request.getActBuseo());
			}
			if(!StringUtils.isEmpty(request.getOcsFlag())) {
				ocs1003.setOcsFlag(request.getOcsFlag());
			}
			if(!StringUtils.isEmpty(request.getSgCode())) {
				ocs1003.setSgCode(request.getSgCode());
			}
			if(!StringUtils.isEmpty(request.getSgYmd())) {
				Date sgYmd = DateUtil.toDate(request.getSgYmd(), DateUtil.PATTERN_YYMMDD);
				ocs1003.setSgYmd(sgYmd);
			}
			if(!StringUtils.isEmpty(request.getIoGubun())) {
				ocs1003.setIoGubun(request.getIoGubun());
			}
			if(!StringUtils.isEmpty(request.getAfterActYn())) {
				ocs1003.setAfterActYn(request.getAfterActYn());
			}
			if(!StringUtils.isEmpty(request.getBichiYn())) {
				ocs1003.setBichiYn(request.getBichiYn());
			}
			if(!StringUtils.isEmpty(request.getDrgBunho())) {
				Double drgBunho = CommonUtils.parseDouble(request.getDrgBunho());
				ocs1003.setDrgBunho(drgBunho);
			}
			if(!StringUtils.isEmpty(request.getSubSusul())) {
				ocs1003.setSubSusul(request.getSubSusul());
			}
			if(!StringUtils.isEmpty(request.getWonyoiOrderYn())) {
				ocs1003.setWonyoiOrderYn(request.getWonyoiOrderYn());
			}
			if(!StringUtils.isEmpty(request.getSutakYn())) {
				ocs1003.setSutakYn(request.getSutakYn());
			}
			if(!StringUtils.isEmpty(request.getPowderYn())) {
				ocs1003.setPowderYn(request.getPowderYn());
			}
			if(!StringUtils.isEmpty(request.getHopeDate())) {
				Date hopeDate = DateUtil.toDate(request.getHopeDate(), DateUtil.PATTERN_YYMMDD);
				ocs1003.setHopeDate(hopeDate);
			}
			if(!StringUtils.isEmpty(request.getHopeTime())) {
				ocs1003.setHopeTime(request.getHopeTime());
			}
			if(!StringUtils.isEmpty(request.getDv1())) {
				Double dv1 = CommonUtils.parseDouble(request.getDv1());
				ocs1003.setDv1(dv1);
			}
			if(!StringUtils.isEmpty(request.getDv2())) {
				Double dv2 = CommonUtils.parseDouble(request.getDv2());
				ocs1003.setDv2(dv2);
			}
			if(!StringUtils.isEmpty(request.getDv3())) {
				Double dv3 = CommonUtils.parseDouble(request.getDv3());
				ocs1003.setDv3(dv3);
			}
			if(!StringUtils.isEmpty(request.getDv4())) {
				Double dv4 = CommonUtils.parseDouble(request.getDv4());
				ocs1003.setDv4(dv4);
			}
			if(!StringUtils.isEmpty(request.getMixGroup())) {
				ocs1003.setMixGroup(request.getMixGroup());
			}
			if(!StringUtils.isEmpty(request.getOrderRemark())) {
				ocs1003.setOrderRemark(request.getOrderRemark());
			}
			if(!StringUtils.isEmpty(request.getNurseRemark())) {
				ocs1003.setNurseRemark(request.getNurseRemark());
			}
			if(!StringUtils.isEmpty(request.getBomOccurYn())) {
				ocs1003.setBomOccurYn(request.getBomOccurYn());
			}
			if(!StringUtils.isEmpty(request.getBomSourceKey())) {
				Double bomSourceKey = CommonUtils.parseDouble(request.getBomSourceKey());
				ocs1003.setBomSourceKey(bomSourceKey);
			}
			if(!StringUtils.isEmpty(request.getDisplayYn())) {
				ocs1003.setDisplayYn(request.getDisplayYn());
			}
			if(!StringUtils.isEmpty(request.getNurseConfirmUser())) {
				ocs1003.setNurseConfirmUser(request.getNurseConfirmUser());
			}
			if(!StringUtils.isEmpty(request.getNurseConfirmDate())) {
				Date nurseConfirmDate = DateUtil.toDate(request.getNurseConfirmDate(), DateUtil.PATTERN_YYMMDD);
				ocs1003.setNurseConfirmDate(nurseConfirmDate);
			}
			if(!StringUtils.isEmpty(request.getNurseConfirmTime())) {
				ocs1003.setNurseConfirmTime(request.getNurseConfirmTime());
			}
			if(!StringUtils.isEmpty(request.getTelYn())) {
				ocs1003.setTelYn(request.getTelYn());
			}
			if(!StringUtils.isEmpty(request.getDangilGumsaOrderYn())) {
				ocs1003.setDangilGumsaOrderYn(request.getDangilGumsaOrderYn());
			}
			if(!StringUtils.isEmpty(request.getDangilGumsaResultYn())) {
				ocs1003.setDangilGumsaResultYn(request.getDangilGumsaResultYn());
			}
			if(!StringUtils.isEmpty(request.getHomeCareYn())) {
				ocs1003.setHomeCareYn(request.getHomeCareYn());
			}
			if(!StringUtils.isEmpty(request.getRegularYn())) {
				ocs1003.setRegularYn(request.getRegularYn());
			}
			if(!StringUtils.isEmpty(request.getInputTab())) {
				ocs1003.setInputTab(request.getInputTab());
			}
			if(!StringUtils.isEmpty(request.getHubalChangeYn())) {
				ocs1003.setHubalChangeYn(request.getHubalChangeYn());
			}
			if(!StringUtils.isEmpty(request.getPharmacy())) {
				ocs1003.setPharmacy(request.getPharmacy());
			}
			if(!StringUtils.isEmpty(request.getJusaSpdGubun())) {
				ocs1003.setJusaSpdGubun(request.getJusaSpdGubun());
			}
			if(!StringUtils.isEmpty(request.getDrgPackYn())) {
				ocs1003.setDrgPackYn(request.getDrgPackYn());
			}
			if(!StringUtils.isEmpty(request.getSortFkocskey())) {
				Double sortFkocskey = CommonUtils.parseDouble(request.getSortFkocskey());
				ocs1003.setSortFkocskey(sortFkocskey);
			}
			if(!StringUtils.isEmpty(request.getFkout1001())) {
				BigDecimal fkout1001 = new BigDecimal(request.getFkout1001());
				ocs1003.setFkout1001(fkout1001);
			}
			if(!StringUtils.isEmpty(request.getImsiDrugYn())) {
				ocs1003.setImsiDrugYn(request.getImsiDrugYn());
			}
			if(!StringUtils.isEmpty(request.getGeneralDispYn())) {
				ocs1003.setGeneralDispYn(request.getGeneralDispYn());
			}
			if(!StringUtils.isEmpty(request.getDv5())) {
				Double dv5 = CommonUtils.parseDouble(request.getDv5());
				ocs1003.setDv5(dv5);
			}
			if(!StringUtils.isEmpty(request.getDv6())) {
				Double dv6 = CommonUtils.parseDouble(request.getDv6());
				ocs1003.setDv6(dv6);
			}
			if(!StringUtils.isEmpty(request.getDv7())) {
				Double dv7 = CommonUtils.parseDouble(request.getDv7());
				ocs1003.setDv7(dv7);
			}
			if(!StringUtils.isEmpty(request.getDv8())) {
				Double dv8 = CommonUtils.parseDouble(request.getDv8());
				ocs1003.setDv8(dv8);
			}
			if(!StringUtils.isEmpty(request.getBogyongCodeSub())) {
				ocs1003.setBogyongCodeSub(request.getBogyongCodeSub());
			}
			if(!StringUtils.isEmpty(request.getInsteadYn())) {
				ocs1003.setInsteadYn(request.getInsteadYn());
			}
			if(!StringUtils.isEmpty(request.getInsteadId())) {
				ocs1003.setInsteadId(request.getInsteadId());
			}
			if(!StringUtils.isEmpty(request.getInsteadDate())) {
				Date insteadDate =  DateUtil.toDate(request.getInsteadDate(), DateUtil.PATTERN_YYMMDD);
				ocs1003.setInsteadDate(insteadDate);
			}
			if(!StringUtils.isEmpty(request.getInsteadTime())) {
				ocs1003.setInsteadTime(request.getInsteadTime());
			}
			if(!StringUtils.isEmpty(request.getApproveYn())) {
				ocs1003.setApproveYn(request.getApproveYn());
			}
			if(!StringUtils.isEmpty(request.getPostapproveYn())) {
				ocs1003.setPostapproveYn(request.getPostapproveYn());
			}
			
			ocs1003Repository.save(ocs1003);
			return true;
	}
}
