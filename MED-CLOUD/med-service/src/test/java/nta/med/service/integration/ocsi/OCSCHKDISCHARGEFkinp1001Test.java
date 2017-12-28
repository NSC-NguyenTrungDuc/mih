package nta.med.service.integration.ocsi;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.vertx.java.core.Vertx;

public class OCSCHKDISCHARGEFkinp1001Test extends MessageRequestTest {
	
	@Autowired
	protected Vertx vertx;

	@Test
	public void Test() throws InterruptedException {
		OcsiServiceProto.OCSCHKDISCHARGEFkinp1001Request request = OcsiServiceProto.OCSCHKDISCHARGEFkinp1001Request.newBuilder()
				.setBunho("000003227")
				.build();
  		
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}