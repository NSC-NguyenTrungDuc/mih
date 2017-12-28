package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inv.Inv4002Repository;
import nta.med.data.model.ihis.invs.INV4001U00Grd4002Info;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001U00Grd4002Request;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001U00Grd4002Response;

@Service
@Scope("prototype")
public class INV4001U00Grd4002Handler extends ScreenHandler<InvsServiceProto.INV4001U00Grd4002Request, InvsServiceProto.INV4001U00Grd4002Response>{
	
	@Resource
	private Inv4002Repository inv4002Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INV4001U00Grd4002Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV4001U00Grd4002Request request) throws Exception {
		InvsServiceProto.INV4001U00Grd4002Response.Builder response = InvsServiceProto.INV4001U00Grd4002Response.newBuilder();
		Double fkinv4001 = CommonUtils.parseDouble(request.getFFkinv4001());
		List<INV4001U00Grd4002Info> grd4002Infos = inv4002Repository.getINV4001U00Grd4002Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), fkinv4001);
		if(!CollectionUtils.isEmpty(grd4002Infos)){
			for(INV4001U00Grd4002Info item : grd4002Infos){
				InvsModelProto.INV4001U00Grd4002Info.Builder info = InvsModelProto.INV4001U00Grd4002Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLst(info);
			}
		}
		return response.build();
	}

}
