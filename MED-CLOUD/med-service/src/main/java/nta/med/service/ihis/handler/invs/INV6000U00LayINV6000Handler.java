package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inv.Inv6000Repository;
import nta.med.data.model.ihis.invs.INV6000U00LayINV6000Info;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class INV6000U00LayINV6000Handler extends ScreenHandler<InvsServiceProto.INV6000U00LayINV6000Request, InvsServiceProto.INV6000U00LayINV6000Response>  {
	@Resource
	private Inv6000Repository inv6000Repository;
    @Override
    public InvsServiceProto.INV6000U00LayINV6000Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
    		InvsServiceProto.INV6000U00LayINV6000Request request) throws Exception {
    	InvsServiceProto.INV6000U00LayINV6000Response.Builder response = InvsServiceProto.INV6000U00LayINV6000Response.newBuilder();
		List<INV6000U00LayINV6000Info> laySumaryDetails = inv6000Repository.getINV6000U00LayINV6000Info(getHospitalCode(vertx, sessionId),request.getMonth());
		if(!CollectionUtils.isEmpty(laySumaryDetails)){
			for(INV6000U00LayINV6000Info item : laySumaryDetails){
				InvsModelProto.INV6000U00LayINV6000Info.Builder info = InvsModelProto.INV6000U00LayINV6000Info.newBuilder();
   			 	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
   			 	if (item.getPkinv6001() != null) {
					info.setPkinv6001(String.format("%.0f",item.getPkinv6001()));
				}
                response.addLayInv6000(info);
			}
		}
        return response.build();
    }
}
