package nta.med.service.ihis.handler.ocso;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.logging.log4j.util.Strings;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.ocs.Ocs1003cRepository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GridOutSangInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GridReserOrderListInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01LayJinryoGwaInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01LayoutQueryInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

@Service
@Scope("prototype")
public class OcsoOCS1003P01BtnListQueryHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01BtnListQueryRequest, OcsoServiceProto.OcsoOCS1003P01BtnListQueryResponse>{
	private static final Log LOG = LogFactory.getLog(OcsoOCS1003P01BtnListQueryHandler.class);
	
	@Resource
	private OutsangRepository outsangRepository;
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Resource
	private Ocs1003Repository ocs1003Repository;

	@Resource
	private Ocs1003cRepository ocs1003cRepository;
	
	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01BtnListQueryResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01BtnListQueryRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01BtnListQueryResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01BtnListQueryResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OcsoOCS1003P01GridOutSangInfo> listOutSang = outsangRepository.getOcsoOCS1003P01GridOutSangInfo(hospCode, language, request.getBunho(),
				request.getGwa(), request.getNaewonDate());
    	if (listOutSang != null && !listOutSang.isEmpty()) {
			for (OcsoOCS1003P01GridOutSangInfo obj : listOutSang) {
				OcsoModelProto.OcsoOCS1003P01GridOutSangInfo.Builder itemBuilder = OcsoModelProto.OcsoOCS1003P01GridOutSangInfo.newBuilder();
				BeanUtils.copyProperties(obj, itemBuilder, getLanguage(vertx, sessionId));
				if (!Strings.isEmpty(obj.getCodeName())) {
					itemBuilder.setCodeName(obj.getCodeName());
				}
				if (!Strings.isEmpty(obj.getSugaSangCode())) {
					itemBuilder.setSugaSangCode(obj.getSugaSangCode());
				}
				response.addGridOutSangItem(itemBuilder);
			}
    	}
    	
    	List<OcsoOCS1003P01LayJinryoGwaInfo> listLayJinryoGwa = bas0260Repository.getOcsoOCS1003P01LayJinryoGwaInfo(hospCode, language);
    	if (listLayJinryoGwa != null && !listLayJinryoGwa.isEmpty()) {
			for (OcsoOCS1003P01LayJinryoGwaInfo obj : listLayJinryoGwa) {
				CommonModelProto.ComboListItemInfo.Builder itemBuilder = CommonModelProto.ComboListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(obj.getGwa())) {
					itemBuilder.setCode(obj.getGwa());
				}
				if (!StringUtils.isEmpty(obj.getGwaName())) {
					itemBuilder.setCodeName(obj.getGwaName());
				}
				response.addCboItem(itemBuilder);
			}
		}
    	
    	Double fkOu1001 = CommonUtils.parseDouble(request.getFkout1001());            	
    	List<OcsoOCS1003P01LayoutQueryInfo> listLayoutQuery = ocs1003Repository.getOcsoOCS1003P01LayoutQueryInfo(language, hospCode,
				request.getBunho(), fkOu1001, request.getQueryGubun(), request.getInputGubun());
    	
    	List<OcsoOCS1003P01LayoutQueryInfo> listLayoutQueryBaseOnOcs1003C = ocs1003cRepository.getOcsoOCS1003P01LayoutQueryInfo(language, hospCode,request.getBunho(), fkOu1001, request.getQueryGubun(), request.getInputGubun(), "");    	
    	if(!CollectionUtils.isEmpty(listLayoutQueryBaseOnOcs1003C)){
    		listLayoutQuery.addAll(listLayoutQueryBaseOnOcs1003C);
    	}
    	
    	// ....
    	List<OcsoOCS1003P01LayoutQueryInfo> tmpList = new ArrayList<OcsoOCS1003P01LayoutQueryInfo>();
    	for (OcsoOCS1003P01LayoutQueryInfo info : listLayoutQuery) {
			if(!tmpList.contains(info)){
				tmpList.add(info);
				for (OcsoOCS1003P01LayoutQueryInfo subInfo : listLayoutQuery) {
					if(subInfo.getBomSourceKey() != null && Double.compare(info.getPkocskey(), subInfo.getBomSourceKey()) == 0){
						tmpList.add(subInfo);
					}
				}
			}
		}
    	// ....
    	
    	if (!CollectionUtils.isEmpty(tmpList)) {
			for (OcsoOCS1003P01LayoutQueryInfo item : tmpList) {
				OcsoModelProto.OcsoOCS1003P01LayoutQueryInfo.Builder info = OcsoModelProto.OcsoOCS1003P01LayoutQueryInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getInOutKey() != null) {
					info.setInOutKey(String.format("%.0f",item.getInOutKey()));
				}
				if (item.getPkocskey() != null) {
					info.setPkocskey(String.format("%.0f",item.getPkocskey()));
				}
				if (item.getJubsuNo() != null) {
					info.setJubsuNo(String.format("%.0f",item.getJubsuNo()));
				}
				if (item.getGroupSer() != null) {
					info.setGroupSer(String.format("%.0f",item.getGroupSer()));
				}
				if (item.getSeq() != null) {
					info.setSeq(String.format("%.0f",item.getSeq()));
				}
				if (item.getSuryang() != null) {
					info.setSuryang(String.format("%.0f",item.getSuryang()));
				}
				if (item.getSunabSuryang() != null) {
					info.setSunabSuryang(String.format("%.0f",item.getSunabSuryang()));
				}
				if (item.getSubulSuryang() != null) {
					info.setSubulSuryang(String.format("%.0f",item.getSubulSuryang()));
				}
				if (item.getDv() != null) {
					info.setDv(String.format("%.0f",item.getDv()));
				}
				if (item.getDv1() != null) {
					info.setDv1(String.format("%.0f",item.getDv1()));
				}
				if (item.getDv2() != null) {
					info.setDv2(String.format("%.0f",item.getDv2()));
				}
				if (item.getDv3() != null) {
					info.setDv3(String.format("%.0f",item.getDv3()));
				}
				if (item.getDv4() != null) {
					info.setDv4(String.format("%.0f",item.getDv4()));
				}
				if (item.getNalsu() != null) {
					info.setNalsu(String.format("%.0f",item.getNalsu()));
				}
				if (item.getAmt() != null) {
					info.setAmt(String.format("%.0f",item.getAmt()));
				}
				if (item.getActingDay() != null) {
					info.setActingDay(String.format("%.0f",item.getActingDay()));
				}
				if (item.getSourceOrdKey() != null) {
					info.setSourceOrdKey(String.format("%.0f",item.getSourceOrdKey()));
				}
				if (item.getDrgBunho() != null) {
					info.setDrgBunho(String.format("%.0f",item.getDrgBunho()));
				}
				if (item.getOrgKey() != null) {
					info.setOrgKey(String.format("%.0f",item.getOrgKey()));
				}
				if (item.getParentKey() != null) {
					info.setParentKey(String.format("%.0f",item.getParentKey()));
				}
				if (item.getDv5() != null) {
					info.setDv5(String.format("%.0f",item.getDv5()));
				}
				if (item.getDv6() != null) {
					info.setDv6(String.format("%.0f",item.getDv6()));
				}
				if (item.getDv7() != null) {
					info.setDv7(String.format("%.0f",item.getDv7()));
				}
				if (item.getDv8() != null) {
					info.setDv8(String.format("%.0f",item.getDv8()));
				}
				if (item.getLimitNalsu() != null) {
					info.setLimitNalsu(String.format("%.0f",item.getLimitNalsu()));
				}
				if (item.getLimitSuryang() != null) {
					info.setLimitSuryang(String.format("%.0f",item.getLimitSuryang()));
				}
				
				if(item.getActionDoYn() != null){
					info.setActionDoYn(item.getActionDoYn());
				}
				
				response.addOutOrder(info);
			}
    	}
    	
    	List<OcsoOCS1003P01GridReserOrderListInfo> listReserOrder = ocs0103Repository.getOcsoOCS1003P01GridReserOrderList(language, hospCode, request.getBunho2(), request.getNaewonDate2());
    	
		List<OcsoOCS1003P01GridReserOrderListInfo> listReserOrderBaseOnOcs1003C = ocs1003cRepository.getOcsoOCS1003P01GridReserOrderList(language, hospCode, request.getBunho2(), request.getNaewonDate2());
    	if(!CollectionUtils.isEmpty(listReserOrderBaseOnOcs1003C)){
    		listReserOrder.addAll(listReserOrderBaseOnOcs1003C);
    	}
    	
    	if (listReserOrder != null && !listReserOrder.isEmpty()) {
			for (OcsoOCS1003P01GridReserOrderListInfo obj : listReserOrder) {
				OcsoModelProto.OcsoOCS1003P01GridReserOrderListInfo.Builder itemBuilder = OcsoModelProto.OcsoOCS1003P01GridReserOrderListInfo.newBuilder();
				BeanUtils.copyProperties(obj, itemBuilder, getLanguage(vertx, sessionId));
				response.addReserOrder(itemBuilder);
			}
    	}
		return response.build();
	}
}
