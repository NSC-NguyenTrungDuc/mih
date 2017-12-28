package nta.med.service.ihis.handler.nuro;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdEditInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ORDERTRANSGrdEditHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSGrdEditRequest, NuroServiceProto.ORDERTRANSGrdEditResponse> {                    
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSGrdEditHandler.class);                                    
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;    
	
	@Override
	public boolean isValid(NuroServiceProto.ORDERTRANSGrdEditRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getActingDate()) && DateUtil.toDate(request.getActingDate(), DateUtil.PATTERN_YYMMDD) == null
				&& !StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSGrdEditResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSGrdEditRequest request) throws Exception {
		NuroServiceProto.ORDERTRANSGrdEditResponse.Builder response = NuroServiceProto.ORDERTRANSGrdEditResponse.newBuilder();
		List<ORDERTRANSGrdEditInfo> listResult = new ArrayList<ORDERTRANSGrdEditInfo>();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Double pk1001 = CommonUtils.parseDouble(request.getPk1001());
		Date actingDate = DateUtil.toDate(request.getActingDate(), DateUtil.PATTERN_YYMMDD);
		listResult = ocs1003Repository.getORDERTRANSGrdEditInfo(hospCode, language, request.getSendYn(), pk1001, actingDate, request.getBunho(), request.getGwa(), request.getDoctor());
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSGrdEditInfo item : listResult){
				NuroModelProto.ORDERTRANSGrdEditInfo.Builder info = NuroModelProto.ORDERTRANSGrdEditInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getPk1001() != null) {
					info.setPk1001(String.format("%.0f",item.getPk1001()));
				}
				if (item.getPkocs() != null) {
					info.setPkocs(String.format("%.0f",item.getPkocs()));
				}
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
				if (item.getSeq() != null) {
					info.setSeq(String.format("%.0f",item.getSeq()));
				}
				if (item.getFkocs003() != null) {
					info.setFkocs003(String.format("%.0f",item.getFkocs003()));
				}
				
				if(item.getOrderStatus() != null){
					info.setOrderStatus(item.getOrderStatus());
				}
				
				response.addGrdEditItem(info);			
			}
		}
		return response.build();
	}                                                                                                                 
}