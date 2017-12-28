package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.nuro.OUT1001R01GrdListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
public class OUT1001R01GrdListHandler extends ScreenHandler<NuroServiceProto.OUT1001R01GrdListRequest, NuroServiceProto.OUT1001R01GrdListResponse> {                             
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT1001R01GrdListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT1001R01GrdListRequest request) throws Exception {
		NuroServiceProto.OUT1001R01GrdListResponse.Builder response = NuroServiceProto.OUT1001R01GrdListResponse.newBuilder(); 
		List<OUT1001R01GrdListInfo> listPatient = bas0001Repository.getOUT1001R01GrdListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getBunho(), request.getNaewonDate());
			if(!CollectionUtils.isEmpty(listPatient)){
				for(OUT1001R01GrdListInfo item : listPatient){
					NuroModelProto.OUT1001R01GrdListInfo.Builder info = NuroModelProto.OUT1001R01GrdListInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addGridList(info);
				}
			}
		return response.build();
	}

}
