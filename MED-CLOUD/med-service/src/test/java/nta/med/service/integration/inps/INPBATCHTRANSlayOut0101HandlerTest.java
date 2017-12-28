package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INPBATCHTRANSlayOut0101HandlerTest extends MessageRequestTest{
	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INPBATCHTRANSlayOut0101Request request = InpsServiceProto.INPBATCHTRANSlayOut0101Request.newBuilder()
				.setBunho("000000002")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
