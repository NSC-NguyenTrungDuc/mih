package nta.med.service.ihis.handler.nuro;

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

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdEditIGubunInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ORDERTRANSGrdEditIGubunHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSGrdEditIGubunRequest, NuroServiceProto.ORDERTRANSGrdEditIGubunResponse> {                      
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSGrdEditIGubunHandler.class);                                    
	@Resource                                                                                                       
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.ORDERTRANSGrdEditIGubunRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSGrdEditIGubunResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSGrdEditIGubunRequest request) throws Exception {
		NuroServiceProto.ORDERTRANSGrdEditIGubunResponse.Builder response = NuroServiceProto.ORDERTRANSGrdEditIGubunResponse.newBuilder();
		Date orderDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
		Double pk1001 = CommonUtils.parseDouble(request.getPk1001());
		List<ORDERTRANSGrdEditIGubunInfo> listResult = ocs2003Repository.getORDERTRANSGrdEditInfoCaseElse(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId) , pk1001, 
				request.getSendYn(), request.getBunho(), orderDate, request.getGwa(), request.getDoctor());
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSGrdEditIGubunInfo item : listResult){
				NuroModelProto.ORDERTRANSGrdEditIGubunInfo.Builder info = NuroModelProto.ORDERTRANSGrdEditIGubunInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if(item.getPk1001() != null){
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
				if (item.getPkocs1003() != null) {
					info.setPkocs1003(String.format("%.0f",item.getPkocs1003()));
				}
				if("Y".equals(item.getTransYn())){
					response.addGrdEditIgubunItem(info);
				}else if("N".equals(item.getTransYn()) && "N".equals(item.getTrialFlg())){
					response.addGrdEditIgubunItem(info);
				}
			}
		}
		return response.build();
	}                                                                                                                 
}