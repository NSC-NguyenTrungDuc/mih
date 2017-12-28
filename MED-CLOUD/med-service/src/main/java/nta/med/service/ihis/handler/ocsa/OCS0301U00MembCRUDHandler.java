package nta.med.service.ihis.handler.ocsa;

import java.math.BigDecimal;
import java.util.Date;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs0300;
import nta.med.core.domain.ocs.Ocs0301;
import nta.med.core.domain.ocs.Ocs0303;
import nta.med.core.domain.ocs.Ocs0307;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs0300Repository;
import nta.med.data.dao.medi.ocs.Ocs0301Repository;
import nta.med.data.dao.medi.ocs.Ocs0303Repository;
import nta.med.data.dao.medi.ocs.Ocs0307Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0301U00MembGrdInfo;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0301U00Membgrd307Info;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0301U00SaveLayoutInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301U00MembCRUDRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class OCS0301U00MembCRUDHandler
	extends ScreenHandler<OcsaServiceProto.OCS0301U00MembCRUDRequest, SystemServiceProto.UpdateResponse> {
	
    @Resource
    private CommonRepository commonRepository;
    
    @Resource
    private Ocs0300Repository ocs0300Repository;
    
    @Resource
    private Ocs0301Repository ocs0301Repository;
    
    @Resource
    private Ocs0303Repository ocs0303Repository;
    
    @Resource
    private Ocs0307Repository ocs0307Repository;
    
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0301U00MembCRUDRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
    
    @Override
    public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0301U00MembCRUDRequest request)
			throws Exception {
			SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = false;
		String hospCode = request.getHospCode();
		// Transactional OCSO300
		if(!CollectionUtils.isEmpty(request.getGrdOCS0300InfoList())){
			for(OCS0301U00MembGrdInfo item : request.getGrdOCS0300InfoList()){
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					Double pkSeq = ocs0300Repository.getMaxPkSeq(hospCode, item.getMembGubun(), item.getMemb());
		    		if(pkSeq == null || pkSeq.equals(new Double(0))){
		    			pkSeq = new  Double(1);
		    		}
		    		if(pkSeq != null){
		    			response.setMsg(String.format("%.0f",pkSeq));
		    		}
		    		result = insertOcs0300(item, pkSeq, request.getUserId(), hospCode);
				}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(ocs0300Repository.updateOCS0301U00(hospCode, CommonUtils.parseDouble(item.getSeq()), item.getYaksokName(), 
							request.getUserId(), new Date(), item.getMembGubun(), item.getMemb(), CommonUtils.parseDouble(item.getKeySeq()))>0){
						result = true;
					}else{
						result = false;
					}
				}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(ocs0300Repository.deleteOCS0301U00(hospCode, item.getMembGubun(), item.getMemb(), CommonUtils.parseDouble(item.getKeySeq())) >0){
						result = true;
					}else{
						result = false;
					}
				}
			}
		}
		// Transactional OCSO301
		if(!CollectionUtils.isEmpty(request.getGrdOCS0301InfoList())){
			for(OCS0301U00MembGrdInfo item : request.getGrdOCS0301InfoList()){
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					result = insertOcs0301(item,request.getUserId(), hospCode);
				}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					Double seq = CommonUtils.parseDouble(item.getSeq());
					Double fkocs0300Seq = CommonUtils.parseDouble(item.getKeySeq());
					if(ocs0301Repository.updateOCS0301U00(hospCode, seq, 
		    				item.getYaksokName(), new Date(), request.getUserId(), item.getMemb(), fkocs0300Seq, item.getYaksok()) > 0){
						result = true;
					}else{
						result = false;
					}
				}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(ocs0301Repository.deleteOCS0301U00(hospCode,item.getMemb(),CommonUtils.parseDouble(item.getKeySeq()), item.getYaksok())>0){
						result = true;
					}else{
						result = false;
					} 
						
				}
			}
		}
		
		// Transactional OCSO303
		if(!CollectionUtils.isEmpty(request.getSaveLayoutInfoList())){
			for(OCS0301U00SaveLayoutInfo item : request.getSaveLayoutInfoList()){
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					String pkocskey = item.getPkocskey();
		    		Double seq = CommonUtils.parseDouble(item.getSeq());
		    		String generalDispYn = item.getGeneralDispYn();
		    		if(StringUtils.isEmpty(item.getPkocskey())) {
		    			pkocskey = commonRepository.getNextVal("OCS0303_SEQ");
		    		}
		    		if(seq == null) {
		    			seq = ocs0303Repository.getMaxSeqByYakSokCodeAndFkocs0300Seq(hospCode, item.getMemb(), item.getYaksokCode(), CommonUtils.parseDouble(item.getSeq()));
		    			if (seq == null) {
		    				seq = new Double(1);
		    			}
		    		}
		    		if(StringUtils.isEmpty(item.getGeneralDispYn())) {
		    			generalDispYn = "N";
		    		}
		    		result = insertOcs0303(item, pkocskey, seq, generalDispYn, request.getUserId(), hospCode);
				}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					Double suryang = CommonUtils.parseDouble(item.getSuryang());
					Double nalsu = CommonUtils.parseDouble(item.getNalsu());
					Double dv1 = CommonUtils.parseDouble(item.getDv1());
					Double dv2 = CommonUtils.parseDouble(item.getDv2());
					Double dv3 = CommonUtils.parseDouble(item.getDv3());
					Double dv4 = CommonUtils.parseDouble(item.getDv4());
					Double dv5 = CommonUtils.parseDouble(item.getDv5());
					Double dv6 = CommonUtils.parseDouble(item.getDv6());
					Double dv7 = CommonUtils.parseDouble(item.getDv7());
					Double dv8 = CommonUtils.parseDouble(item.getDv8());
					Double bomSourceKey = CommonUtils.parseDouble(item.getBomSourceKey());
					Double dv = CommonUtils.parseDouble(item.getDv());
					Double seq = CommonUtils.parseDouble(item.getSeq());
					Double pkocs0303 = CommonUtils.parseDouble(item.getPkocskey());
					
					ocs0303Repository.updateOcs0301u00(new Date(), request.getUserId(), item.getNdayYn(), suryang,
							nalsu, item.getJusa(), item.getBogyongCode(), item.getEmergency(), item.getMuhyo(), item.getPowderYn(),
							dv1, dv2, dv3, dv4, dv5, dv6, dv7, dv8, item.getMixGroup(), item.getOrderRemark(), item.getNurseRemark(),
							item.getWonyoiOrderYn(), bomSourceKey, item.getHubalChangeYn(), item.getPharmacy(), item.getJusaSpdGubun(),
							item.getDrgPackYn(), item.getDangilGumsaOrderYn(), item.getDangilGumsaResultYn(), item.getDvTime(),
							dv, item.getOrdDanui(), item.getSpecimenCode(), item.getJundalTableOut(), item.getJundalPartOut(),
							item.getJundalTableInp(), item.getJundalPartInp(), item.getMovePartOut(), item.getMovePartInp(),
							item.getGeneralDispYn(), seq, hospCode, pkocs0303);
					result = true;
				}
			}
		}
		
		//
		if(!CollectionUtils.isEmpty(request.getDeleteLayoutInfoList())){
			for(OCS0301U00SaveLayoutInfo item : request.getDeleteLayoutInfoList()){
				Double pkocs0303 = CommonUtils.parseDouble(item.getPkocskey());
				ocs0303Repository.deleteOcs0301u00(hospCode, pkocs0303);
				result = true;
			}
		}
		
		//OCS0307
		if(!CollectionUtils.isEmpty(request.getGrdOCS0307InfoList())) {
			for (OCS0301U00Membgrd307Info item : request.getGrdOCS0307InfoList()) {
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
					result = insertOcs0307(item, request.getUserId(), hospCode);
				} else if (item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
					if(ocs0307Repository.deleteOcs0307u00(hospCode, item.getMemb(), CommonUtils.parseLong(item.getPkocs0307()), new BigDecimal(0)) >0){
						result = true;
					}else{
						result = false;
					} 
				}
			}
		}
		response.setResult(result);
		return response.build();
	}
				
    
    private boolean insertOcs0300(OCS0301U00MembGrdInfo item, Double pkSeq, String userId, String hospCode) {
    	Ocs0300 ocs0300 = new Ocs0300();
    	ocs0300.setSysDate(new Date());
    	ocs0300.setSysId(userId);
    	ocs0300.setUpdDate(new Date());
    	ocs0300.setUpdId(userId);
    	ocs0300.setHospCode(hospCode);
    	ocs0300.setMemb(item.getMemb());
    	ocs0300.setPkSeq(pkSeq);
    	ocs0300.setYaksokGubun(item.getYaksok());
    	ocs0300.setYaksokGubunName(item.getYaksokName());
    	ocs0300.setSeq(StringUtils.isEmpty(item.getSeq()) ? null : new Double(item.getSeq()));
    	ocs0300.setMembGubun(item.getMembGubun());
    	ocs0300.setInputTab(item.getInputTab());
    	ocs0300Repository.save(ocs0300);
    	return true;
    }
    
    private boolean insertOcs0301(OCS0301U00MembGrdInfo item,String userId, String hospCode) {
    	Ocs0301 ocs0301 = new Ocs0301();
    	ocs0301.setSysDate(new Date());
    	ocs0301.setSysId(userId);
    	ocs0301.setUpdDate(new Date());
    	ocs0301.setUpdId(userId);
    	ocs0301.setMemb(item.getMemb());
    	ocs0301.setYaksokCode(item.getYaksok());
    	ocs0301.setYaksokName(item.getYaksokName());
    	ocs0301.setSeq(StringUtils.isEmpty(item.getSeq()) ? null : new Double(item.getSeq()));
    	ocs0301.setFkocs0300Seq(StringUtils.isEmpty(item.getKeySeq()) ? null : new Double(item.getKeySeq()));
    	ocs0301.setHospCode(hospCode);
    	ocs0301.setMembGubun(item.getMembGubun());
    	ocs0301Repository.save(ocs0301);
    	return true;
    }
     
    private boolean insertOcs0303(OCS0301U00SaveLayoutInfo item, String pkocskey, Double seq, String generalDispYn, String userId, String hospCode) {
    	Ocs0303 ocs0303 = new Ocs0303();
    	ocs0303.setSysDate(new Date());
    	ocs0303.setSysId(userId);
    	ocs0303.setUpdDate(new Date());
    	ocs0303.setMemb(item.getMemb());
    	ocs0303.setYaksokCode(item.getYaksokCode());
    	ocs0303.setGroupSer(CommonUtils.parseDouble(item.getGroupSer()));
    	ocs0303.setHangmogCode(item.getHangmogCode());
    	ocs0303.setSeq(seq);
    	ocs0303.setPkocs0303(CommonUtils.parseDouble(pkocskey));
    	ocs0303.setSpecimenCode(item.getSpecimenCode());
    	ocs0303.setSuryang(CommonUtils.parseDouble(item.getSuryang()));
    	ocs0303.setOrdDanui(item.getOrdDanui());
    	ocs0303.setDvTime(item.getDvTime());
    	ocs0303.setDv(CommonUtils.parseDouble(item.getDv()));
    	ocs0303.setNalsu(CommonUtils.parseDouble(item.getNalsu()));
    	ocs0303.setJusa(item.getJusa());
    	ocs0303.setBogyongCode(item.getBogyongCode());
    	ocs0303.setEmergency(item.getEmergency());
    	ocs0303.setMuhyo(item.getMuhyo());
    	ocs0303.setPortableYn(item.getPortableYn());
    	ocs0303.setPay(item.getPay());
    	ocs0303.setPrnYn("N");
    	ocs0303.setPowderYn(item.getPowderYn());
    	ocs0303.setDv1(CommonUtils.parseDouble(item.getDv1()));
    	ocs0303.setDv2(CommonUtils.parseDouble(item.getDv2()));
    	ocs0303.setDv3(CommonUtils.parseDouble(item.getDv3()));
    	ocs0303.setDv4(CommonUtils.parseDouble(item.getDv4()));
    	ocs0303.setMixGroup(item.getMixGroup());
    	ocs0303.setDv5(CommonUtils.parseDouble(item.getDv5()));
    	ocs0303.setDv6(CommonUtils.parseDouble(item.getDv6()));
    	ocs0303.setDv7(CommonUtils.parseDouble(item.getDv7()));
    	ocs0303.setDv8(CommonUtils.parseDouble(item.getDv8()));
    	ocs0303.setOrderRemark(item.getOrderRemark());
    	ocs0303.setNurseRemark(item.getNurseRemark());
    	ocs0303.setOrderGubun(item.getOrderGubun());
    	ocs0303.setWonyoiOrderYn(item.getWonyoiOrderYn());
    	ocs0303.setDangilGumsaOrderYn(item.getDangilGumsaOrderYn());
    	ocs0303.setDangilGumsaResultYn(item.getDangilGumsaResultYn());
    	ocs0303.setInputTab(item.getInputTab());
    	ocs0303.setHubalChangeYn(item.getHubulChangeYn());
    	ocs0303.setPharmacy(item.getPharmacy());
    	ocs0303.setJusaSpdGubun(item.getJusaSpdGubun());
    	ocs0303.setDrgPackYn(item.getDrgPackYn());
    	ocs0303.setUpdId(userId);
    	ocs0303.setHospCode(hospCode);
    	ocs0303.setMembGubun("00");
    	ocs0303.setHangmogCode(item.getHangmogCode());
    	ocs0303.setAmt(CommonUtils.parseDouble(item.getAmt()));
    	ocs0303.setBomSourceKey(CommonUtils.parseDouble(item.getBomSourceKey()));
    	ocs0303.setNdayYn(item.getNdayYn());
    	ocs0303.setFkocs0300Seq(CommonUtils.parseDouble(item.getInOutKey()));
    	ocs0303.setJundalTableOut(item.getJundalTableOut());
    	ocs0303.setJundalPartOut(item.getJundalPartOut());
    	ocs0303.setJundalTableInp(item.getJundalTableInp());
    	ocs0303.setJundalPartInp(item.getJundalPartInp());
    	ocs0303.setMovePartOut(item.getMovePartOut());
    	ocs0303.setMovePartInp(item.getMovePartInp());
    	ocs0303.setGeneralDispYn(generalDispYn);
    	ocs0303Repository.save(ocs0303);
    	return true;
    }
    
    private boolean insertOcs0307(OCS0301U00Membgrd307Info item, String userId, String hospCode) {
    	Ocs0307 ocs0307 = new Ocs0307();
    	ocs0307.setSysDate(new Date());
    	ocs0307.setSysId(userId);
    	ocs0307.setUpdDate(new Date());
    	ocs0307.setUpdId(userId);
    	ocs0307.setMemb(item.getMemb());
    	ocs0307.setYaksokCode(item.getYaksokCode());
    	ocs0307.setSangCode(item.getSangCode());
    	ocs0307.setFkocs0307Seq(CommonUtils.parseDouble(item.getFkocs0300Seq()));
    	ocs0307.setHospCode(hospCode);
    	ocs0307.setActiveFlg(new BigDecimal(1));
    	ocs0307Repository.save(ocs0307);
    	return true;
    }

}
