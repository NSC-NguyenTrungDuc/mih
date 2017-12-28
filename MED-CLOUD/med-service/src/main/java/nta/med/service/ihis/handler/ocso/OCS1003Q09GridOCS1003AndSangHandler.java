package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.ocsa.OCS1003Q09GridSangInfo;
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
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS1003Q09GridOCS1003AndSangHandler extends ScreenHandler<OcsoServiceProto.OCS1003Q09GridOCS1003AndSangRequest, OcsoServiceProto.OCS1003Q09GridOCS1003AndSangResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS1003Q09GridOCS1003AndSangHandler.class);                                    
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;  
	@Resource
	private OutsangRepository outsangRepository;
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1003Q09GridOCS1003AndSangResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1003Q09GridOCS1003AndSangRequest request) throws Exception {
		OcsoServiceProto.OCS1003Q09GridOCS1003AndSangResponse.Builder response = OcsoServiceProto.OCS1003Q09GridOCS1003AndSangResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<OCS1003Q09GridSangInfo> listGridSangInfo =  outsangRepository.getOCS1003Q09GridSangListItem(hospCode, language,
				request.getGrdsangIoGubun(), request.getGrdsangJubsuNo(), DateUtil.toDate(request.getGrdsangNaewonDate(), DateUtil.PATTERN_YYMMDD) , request.getGrdsangGwa(), 
				request.getGrdsangDoctor(), request.getGrdsangNaewonType(), request.getGrdsangBunho());
		if(!CollectionUtils.isEmpty(listGridSangInfo)){
			for(OCS1003Q09GridSangInfo item : listGridSangInfo){
				OcsoModelProto.OCS1003Q09GridSangInfo.Builder info = OcsoModelProto.OCS1003Q09GridSangInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				info.setSer(String.format("%.0f",item.getSer()));
				info.setJubsuNo(String.format("%.0f",item.getJubsuNo()));
				response.addGridSangInfo(info);
			}
		}
	List<OcsoOCS1003Q05OrderListItemInfo> listGridOCS1003 =  ocs1003Repository.getOcsoOCS1003Q05OrderList(hospCode, language,
		request.getGrdocs1003GenericYn(), request.getGrdocs1003PkOrder(), request.getGrdocs1003InputTab(), request.getGrdocs1003InputGubun(),
		request.getGrdocs1003TelYn(), request.getGrdocs1003Bunho(), request.getGrdocs1003JubsuNo(), request.getGrdocs1003Kijun(),  DateUtil.toDate(request.getGrdocs1003NaewonDate(), DateUtil.PATTERN_YYMMDD),
		request.getGrdocs1003Gwa(), request.getGrdocs1003Doctor());
		if(!CollectionUtils.isEmpty(listGridOCS1003)){
			for(OcsoOCS1003Q05OrderListItemInfo item : listGridOCS1003){
				OcsoModelProto.OcsoOCS1003Q05OrderListItemInfo.Builder info = OcsoModelProto.OcsoOCS1003Q05OrderListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				info.setGroupSer(String.format("%.0f",item.getGroupSer()));
				info.setSuryang(String.format("%.0f",item.getSuryang()));
				info.setDv(String.format("%.0f",item.getDv()));
				info.setNalsu(String.format("%.0f",item.getNalsu()));
				info.setPkOrder(String.format("%.0f",item.getPkOrder()));
				info.setSeq(String.format("%.0f",item.getSeq()));
				info.setPkocs1003(String.format("%.0f",item.getPkocs1003()));
				info.setAmt(String.format("%.0f",item.getAmt()));
				info.setDv1(String.format("%.0f",item.getDv1()));
				info.setDv2(String.format("%.0f",item.getDv2()));
				info.setDv3(String.format("%.0f",item.getDv3()));
				info.setDv4(String.format("%.0f",item.getDv4()));
				info.setLimitSuryang(String.format("%.0f",item.getLimitSuryang()));
				info.setOrgKey(String.format("%.0f",item.getOrgKey()));
				info.setFkout1001(String.format("%.0f",item.getFkout1001()));
				info.setDv5(String.format("%.0f",item.getDv5()));
				info.setDv6(String.format("%.0f",item.getDv6()));
				info.setDv7(String.format("%.0f",item.getDv7()));
				info.setDv8(String.format("%.0f",item.getDv8()));
				response.addGridOcs1003Info(info);
				
				
			}
		}
		return response.build();
	}                                                                                                                 
}