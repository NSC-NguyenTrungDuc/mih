package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.ocso.OCS1003R00LayOCS1001Info;
import nta.med.data.model.ihis.ocso.OCS1003R00LayOCS1003Info;
import nta.med.data.model.ihis.ocso.OCS1003R00LayOUT1001Info;
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
public class OCS1003R00FormLoadHandler extends ScreenHandler<OcsoServiceProto.OCS1003R00FormLoadRequest, OcsoServiceProto.OCS1003R00FormLoadResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS1003R00FormLoadHandler.class);                                    
	@Resource                                                                                                       
	private OutsangRepository outsangRepository;  
	@Resource
	private Ocs1003Repository ocs1003Repository;
	@Resource
	private Out0101Repository out0101Repository;
	                                                                                                                
	@Override
	public boolean isValid(OcsoServiceProto.OCS1003R00FormLoadRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1003R00FormLoadResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1003R00FormLoadRequest request) throws Exception {
		OcsoServiceProto.OCS1003R00FormLoadResponse.Builder response = OcsoServiceProto.OCS1003R00FormLoadResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		//list OCS1003R00LayOCS1001Info
		List<OCS1003R00LayOCS1001Info> listLayOcs1001 = outsangRepository.getOCS1003R00LayOCS1001Info(hospCode, request.getBunho(), request.getGwa(),
				request.getDoctor(), request.getJubsuNo(), request.getNaewonDate());
		if(!CollectionUtils.isEmpty(listLayOcs1001)){
			for(OCS1003R00LayOCS1001Info item : listLayOcs1001){
				OcsoModelProto.OCS1003R00LayOCS1001Info.Builder info = OcsoModelProto.OCS1003R00LayOCS1001Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					if (item.getSer() != null) {
			        info.setSer(String.format("%.0f", item.getSer()));
			       }
				response.addOcs1001Item(info);
			}
		}
		//list OCS1003R00LayOCS1003Info
		List<OCS1003R00LayOCS1003Info> listLayOcs1003 = ocs1003Repository.getOCS1003R00LayOCS1003Info(hospCode, language, request.getBunho(),
			request.getNaewonDate(),request.getGwa(),request.getDoctor(),request.getNaewonType(),request.getInputGubun());
		if(!CollectionUtils.isEmpty(listLayOcs1003)){
			for(OCS1003R00LayOCS1003Info item : listLayOcs1003){
				OcsoModelProto.OCS1003R00LayOCS1003Info.Builder info = OcsoModelProto.OCS1003R00LayOCS1003Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getGroupSer() != null) {
					info.setGroupSer(String.format("%.0f", item.getGroupSer()));
				}
				if (item.getSeq() != null) {
					info.setSeq(String.format("%.0f", item.getSeq()));
				}
				response.addOcs1003Item(info);
			}
		}
		//list OCS1003R00LayOUT1001Info
		List<OCS1003R00LayOUT1001Info> listLayOut1001 = out0101Repository.getOCS1003R00LayOUT1001Info(hospCode, language, request.getInputGubun(), DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD),
						request.getBunho(), request.getGwa(), request.getDoctor(), request.getNaewonType(), request.getJubsuNo());
		if (!CollectionUtils.isEmpty(listLayOut1001)) {
			for (OCS1003R00LayOUT1001Info item : listLayOut1001) {
				OcsoModelProto.OCS1003R00LayOUT1001Info.Builder info = OcsoModelProto.OCS1003R00LayOUT1001Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if(!StringUtils.isEmpty(item.getDoctoName())){
					info.setDoctorName(item.getDoctoName());
				}
				response.addOut1001Item(info);
			}
		}
		return response.build();
	}                                                                                                                 
}