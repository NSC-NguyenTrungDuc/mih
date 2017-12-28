package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.ocso.OCS1003Q02LayQueryLayoutInfo;
import nta.med.data.model.ihis.ocso.OCS1003Q02grdOCS1001Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS1003GrdOUT1001RowFocusChangedHandler extends ScreenHandler<OcsoServiceProto.OCS1003GrdOUT1001RowFocusChangedRequest, OcsoServiceProto.OCS1003GrdOUT1001RowFocusChangedResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(OCS1003GrdOUT1001RowFocusChangedHandler.class);                                    
	@Resource                                                                                                       
	private OutsangRepository outsangRepository; 
	@Resource
	private Ocs1003Repository ocs1003Repository;
	                                                                                                                
	@Override
	public boolean isValid(OcsoServiceProto.OCS1003GrdOUT1001RowFocusChangedRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1003GrdOUT1001RowFocusChangedResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OcsoServiceProto.OCS1003GrdOUT1001RowFocusChangedRequest request)throws Exception {
		OcsoServiceProto.OCS1003GrdOUT1001RowFocusChangedResponse.Builder response = OcsoServiceProto.OCS1003GrdOUT1001RowFocusChangedResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<OCS1003Q02grdOCS1001Info> listGrdOcs1001 = outsangRepository
				.getOCS1003Q02grdOCS1001Info(hospCode, request.getBunho(), request.getGwa(), DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD));
		if (!CollectionUtils.isEmpty(listGrdOcs1001)) {
			for (OCS1003Q02grdOCS1001Info item : listGrdOcs1001) {
				OcsoModelProto.OCS1003Q02grdOCS1001Info.Builder info = OcsoModelProto.OCS1003Q02grdOCS1001Info
						.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getSer() != null) {
					info.setSer(String.format("%.0f", item.getSer()));
				}
				if (item.getJubsuno() != null) {
					info.setJubsuNo(String.format("%.0f", item.getJubsuno()));
				}
				response.addGrdOcs1001Info(info);
			}
		}
		List<OCS1003Q02LayQueryLayoutInfo> listLayQuery = ocs1003Repository
				.getOCS1003Q02LayQueryLayoutInfo(hospCode, language, request.getBunho(),
						CommonUtils.parseDouble(request.getFkout1001()), request.getQueryGubun(), request.getInputGubun());
		if (!CollectionUtils.isEmpty(listLayQuery)) {
			for (OCS1003Q02LayQueryLayoutInfo item : listLayQuery) {
				OcsoModelProto.OCS1003Q02LayQueryLayoutInfo.Builder info = OcsoModelProto.OCS1003Q02LayQueryLayoutInfo
						.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getInOutKey() != null) {
					info.setInOutKey(String.format("%.0f", item.getInOutKey()));
				}
				if (item.getPkocskey() != null) {
					info.setPkocskey(String.format("%.0f", item.getPkocskey()));
				}
				if (item.getJubsuNo() != null) {
					info.setJubsuNo(String.format("%.0f", item.getJubsuNo()));
				}
				if (item.getGroupSer() != null) {
					info.setGroupSer(String.format("%.0f", item.getGroupSer()));
				}
				if (item.getSeq() != null) {
					info.setSeq(String.format("%.0f", item.getSeq()));
				}
				if (item.getSuryang() != null) {
					info.setSuryang(String.format("%.0f", item.getSuryang()));
				}
				if (item.getSunabSuryang() != null) {
					info.setSunabSuryang(String.format("%.0f",
							item.getSunabSuryang()));
				}
				if (item.getDv() != null) {
					info.setDv(String.format("%.0f", item.getDv()));
				}
				if (item.getDv1() != null) {
					info.setDv1(String.format("%.0f", item.getDv1()));
				}
				if (item.getDv2() != null) {
					info.setDv2(String.format("%.0f", item.getDv2()));
				}
				if (item.getDv3() != null) {
					info.setDv3(String.format("%.0f", item.getDv3()));
				}
				if (item.getDv4() != null) {
					info.setDv4(String.format("%.0f", item.getDv4()));
				}
				if (item.getNalsu() != null) {
					info.setNalsu(String.format("%.0f", item.getNalsu()));
				}
				if (item.getAmt() != null) {
					info.setAmt(String.format("%.0f", item.getAmt()));
				}
				if (item.getOrgKey() != null) {
					info.setOrgKey(String.format("%.0f", item.getOrgKey()));
				}
				if (item.getDv5() != null) {
					info.setDv5(String.format("%.0f", item.getDv5()));
				}
				if (item.getDv6() != null) {
					info.setDv6(String.format("%.0f", item.getDv6()));
				}
				if (item.getDv7() != null) {
					info.setDv7(String.format("%.0f", item.getDv7()));
				}
				if (item.getDv8() != null) {
					info.setDv8(String.format("%.0f", item.getDv8()));
				}
				response.setLayQueryLayoutInfo(info);
			}
		}
		return response.build();
	}
}