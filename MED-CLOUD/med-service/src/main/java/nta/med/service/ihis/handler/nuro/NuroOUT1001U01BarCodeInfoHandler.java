package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01LayoutBarCodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")


public class NuroOUT1001U01BarCodeInfoHandler  extends ScreenHandler<NuroServiceProto.NuroOUT1001U01BarCodeInfoRequest, NuroServiceProto.NuroOUT1001U01LayoutBarCodeInfoResponse> {
private static final Log LOGGER = LogFactory.getLog(NuroOUT1001U01BarCodeInfoHandler.class);
	
	@Resource
	private Out1001Repository Out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01LayoutBarCodeInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01BarCodeInfoRequest request) throws Exception {
		NuroServiceProto.NuroOUT1001U01LayoutBarCodeInfoResponse.Builder response = NuroServiceProto.NuroOUT1001U01LayoutBarCodeInfoResponse.newBuilder();
		List<NuroOUT1001U01LayoutBarCodeInfo> listNuroOUT1001U01LayoutBarCodeInfo = Out1001Repository.getNuroOUT1001U01LayoutBarCodeInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho());
		if(listNuroOUT1001U01LayoutBarCodeInfo != null && !listNuroOUT1001U01LayoutBarCodeInfo.isEmpty()){
			for(NuroOUT1001U01LayoutBarCodeInfo item : listNuroOUT1001U01LayoutBarCodeInfo){
				NuroModelProto.NuroOUT1001U01LayoutBarCodeInfo.Builder nuroLayoutBarCodeInfo = NuroModelProto.NuroOUT1001U01LayoutBarCodeInfo.newBuilder();
				
				if(item.getBunho() != null){
					nuroLayoutBarCodeInfo.setBunho(item.getBunho());
				}
				if(item.getSex()!= null){
					nuroLayoutBarCodeInfo.setSex(item.getSex());
				}
				if(item.getSuname() != null){
					nuroLayoutBarCodeInfo.setSuname(item.getSuname());
				}
				if(item.getBirth() != null){
					nuroLayoutBarCodeInfo.setBirth(item.getBirth());
				}
				if(item.getBunho2() != null){
					nuroLayoutBarCodeInfo.setBunho2(item.getBunho2());
				}
				response.addBarCodeItem(nuroLayoutBarCodeInfo);
			}
		}
		return response.build();
	}
}
