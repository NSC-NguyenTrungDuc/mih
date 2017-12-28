package nta.med.service.ihis.handler.ocso;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.ocso.OcsoOCS1003Q05OrderListItemInfo;
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

import javax.annotation.Resource;
import java.util.List;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS1003Q09GridOCS1003Handler extends ScreenHandler<OcsoServiceProto.OCS1003Q09GridOCS1003Request, OcsoServiceProto.OCS1003Q09GridOCS1003Response> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS1003Q09GridOCS1003Handler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;         
	@Resource
	private Ocs1003Repository ocs1003Repository;
	                                                                                                                
	@Override
	public boolean isValid(OcsoServiceProto.OCS1003Q09GridOCS1003Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1003Q09GridOCS1003Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1003Q09GridOCS1003Request request) throws Exception {
		OcsoServiceProto.OCS1003Q09GridOCS1003Response.Builder response = OcsoServiceProto.OCS1003Q09GridOCS1003Response.newBuilder();
		List<OcsoOCS1003Q05OrderListItemInfo > listOrder = ocs1003Repository.getOcsoOCS1003Q05OrderList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getGenericYn(), request.getPkOrder(), request.getInputTab(), request.getInputGubun(), request.getTelYn(), 
				request.getBunho(), request.getJubsuNo(), request.getKijun(), DateUtil.toDate(request.getNaewonDate(),DateUtil.PATTERN_YYMMDD), request.getGwa(), request.getDoctor());
		if (!CollectionUtils.isEmpty(listOrder)) {
			for (OcsoOCS1003Q05OrderListItemInfo  item : listOrder) {
				OcsoModelProto.OcsoOCS1003Q05OrderListItemInfo .Builder info = OcsoModelProto.OcsoOCS1003Q05OrderListItemInfo .newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getGroupSer() != null) {
					info.setGroupSer(String.format("%.0f",item.getGroupSer()));
				}
				if (item.getSuryang() != null) {
					info.setSuryang(String.format("%.0f",item.getSuryang()));
				}
				if (item.getDv() != null) {
					info.setDv(String.format("%.0f",item.getDv()));
				}
				if (item.getNalsu() != null) {
					info.setNalsu(String.format("%.0f",item.getNalsu()));
				}				
				if (item.getPkOrder() != null) {
					info.setPkOrder(String.format("%.0f",item.getPkOrder()));
				}
				if (item.getSeq() != null) {
					info.setSeq(String.format("%.0f",item.getSeq()));
				}
				if (item.getPkocs1003() != null) {
					info.setPkocs1003(String.format("%.0f",item.getPkocs1003()));
				}
				if (item.getAmt() != null) {
					info.setAmt(String.format("%.0f",item.getAmt()));
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
				if (item.getLimitSuryang() != null) {
					info.setLimitSuryang(String.format("%.0f",item.getLimitSuryang()));
				}
				if (item.getOrgKey() != null) {
					info.setOrgKey(String.format("%.0f",item.getOrgKey()));
				}
				if (item.getFkout1001() != null) {
					info.setFkout1001(String.format("%.0f",item.getFkout1001()));
				}
				if (item.getDv5() !=null) {
					info.setDv5(String.format("%.0f",item.getDv5()));
				}
				if (item.getDv6() !=null) {
					info.setDv6(String.format("%.0f",item.getDv6()));
				}
				if (item.getDv7() !=null) {
					info.setDv7(String.format("%.0f",item.getDv7()));
				}
				if (item.getDv8()!=null) {
					info.setDv8(String.format("%.0f",item.getDv8()));
				}
				if (item.getBomSourceKey()!=null) {
					info.setBomSourceKey(String.format("%.0f",item.getBomSourceKey()));
				}
				if (item.getParentKey()!=null) {
					info.setParentKey(String.format("%.0f",item.getParentKey()));
				}
				response.addRidOcs1003Info(info);
			}
		}
		return response.build();
	}      
}