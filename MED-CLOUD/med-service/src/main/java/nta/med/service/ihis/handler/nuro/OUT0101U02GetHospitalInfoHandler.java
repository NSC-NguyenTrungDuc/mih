package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02HospitalItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class OUT0101U02GetHospitalInfoHandler extends ScreenHandler<NuroServiceProto.OUT0101U02GetHospitalInfoRequest, NuroServiceProto.OUT0101U02GetHospitalInfoResponse> {                             
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT0101U02GetHospitalInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0101U02GetHospitalInfoRequest request) throws Exception {
		NuroServiceProto.OUT0101U02GetHospitalInfoResponse.Builder response = NuroServiceProto. OUT0101U02GetHospitalInfoResponse.newBuilder();
		
		List<NuroOUT0101U02HospitalItemInfo> list = out0101Repository.getNuroOUT0101U02HospitalListInfo( request.getHospCode(), getLanguage(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(list)){
			for(NuroOUT0101U02HospitalItemInfo item : list){
				NuroModelProto.OUT0101U02HospitalItemInfo.Builder info = NuroModelProto.OUT0101U02HospitalItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));

				response.addHospList(info);
			}
		}
		return response.build();
	}

}
