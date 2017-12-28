package nta.med.service.ihis.handler.drgs;

import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

@Service
@Scope("prototype")
public class DrgsDRG5100P01CommentNumberHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01CommentNumberRequest, DrgsServiceProto.DrgsDRG5100P01CommentNumberResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01CommentNumberHandler.class);
	@Resource
	private Drg2010Repository drg2010Repository;

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG5100P01CommentNumberResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01CommentNumberRequest request) throws Exception {
        String result = drg2010Repository.getDrgsDRG5100P01CommentNumber(request.getIComments(), request.getRowNumber());
        DrgsServiceProto.DrgsDRG5100P01CommentNumberResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01CommentNumberResponse.newBuilder();
        if (!StringUtils.isEmpty(result)) {
            response.setOComments(result);
        }
        return response.build();
    }
}
